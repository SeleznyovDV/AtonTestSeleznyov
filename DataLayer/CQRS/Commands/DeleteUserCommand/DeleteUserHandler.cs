using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.CurrentUserService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.DeleteUserCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, UserDto>
    {
        private readonly AppDbContext _db;
        private readonly ICurrentUserService _cus;
        public DeleteUserHandler(AppDbContext db, ICurrentUserService cus)
        {
            _db = db;
            _cus = cus;
        }
        public async Task<UserDto> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (_cus.GetUserLogin() ==  user.Login)
                throw new SelfDeletingException();

            if (request.dto.SoftRemoval)
            {
                if (user.IsDeleted())
                    throw new RevokedUserException();

                user.Revoke(_cus.GetUserLogin());
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
