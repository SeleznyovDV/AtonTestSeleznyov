using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.CurrentUserService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.Update1UserPassword
{
    public class Update1UserPasswordHandler : IRequestHandler<Update1UserPasswordRequest, UserDto>
    {
        private readonly AppDbContext _db;
        private readonly ICurrentUserService _cus;
        public Update1UserPasswordHandler(AppDbContext db, ICurrentUserService cus)
        {
            _db = db;
            _cus = cus;
        }
        public async Task<UserDto> Handle(Update1UserPasswordRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var currentUser = await _db.User.FirstOrDefaultAsync(user => user.Login == _cus.GetUserLogin());

            if (currentUser.Admin == false && currentUser.Login != request.dto.Login)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (user.IsDeleted())
                throw new RevokedUserException();

            if (user.Password == request.dto.Password)
                throw new EqualPasswordsException();
            
            user.Password = request.dto.Password;

            user.Validate();

            _db.Update(user);
            await _db.SaveChangesAsync();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
