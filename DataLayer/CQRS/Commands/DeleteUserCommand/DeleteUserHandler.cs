using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.AuthorizationService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.DeleteUserCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, UserDto>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;
        public DeleteUserHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }
        public async Task<UserDto> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);

            if (currentUser.Admin == false)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (currentUser.Equals(user))
                throw new SelfDeletingException();

            if (request.dto.SoftRemoval)
            {
                if (user.IsDeleted())
                    throw new RevokedUserException();

                user.Revoke(currentUser.Login);
            }
            else
            {
                _db.User.Remove(user);
            }
            
            await _db.SaveChangesAsync();
            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
