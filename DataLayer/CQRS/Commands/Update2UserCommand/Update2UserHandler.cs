using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.CurrentUserService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.Update2UserCommand
{
    public class Update2UserHandler : IRequestHandler<Update2UserRequest, UserDto>
    {
        private readonly AppDbContext _db;
        private readonly ICurrentUserService _cus;
        public Update2UserHandler(AppDbContext db, ICurrentUserService cus)
        {
            _db = db;
            _cus = cus;
        }
        public async Task<UserDto> Handle(Update2UserRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var currentUser = await _db.User.FirstOrDefaultAsync(user => user.Login == _cus.GetUserLogin());

            if (currentUser.Admin == false)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (user.RevokedBy == null)
                throw new UnRevokedUserException();

            user.UnRevoke();
            _db.Update(user);
            await _db.SaveChangesAsync();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
