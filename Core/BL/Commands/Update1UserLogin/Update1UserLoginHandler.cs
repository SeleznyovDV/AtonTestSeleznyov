using Core.BL.Dto.Response;
using Core.Exceptions;
using Core.Services.CurrentUserService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Bl.Commands.Update1UserLogin
{
    public class Update1UserLoginHandler : IRequestHandler<Update1UserLoginRequest, UserDto>
    {
        private readonly AppDbContext _db;
        private readonly ICurrentUserService _cus;
        public Update1UserLoginHandler(AppDbContext db, ICurrentUserService cus)
        {
            _db = db;
            _cus = cus;
        }
        public async Task<UserDto> Handle(Update1UserLoginRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var currentUser = await _db.Users.FirstOrDefaultAsync(user => user.Login == _cus.GetUserLogin());

            if (currentUser.Admin == false && currentUser.Login != request.dto.Login)
                throw new AccessRightsException();

            var user = await _db.Users.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (user.IsDeleted())
                throw new RevokedUserException();

            if (request.dto.Login == request.dto.NewLogin)
                throw new EqualLoginsException();

            if (await _db.Users.FirstOrDefaultAsync(x => x.Login == request.dto.NewLogin) != null)
                throw new UserAlreadyExistsException();
            
            user.Login = request.dto.NewLogin;

            user.Validate();

            _db.Update(user);
            await _db.SaveChangesAsync();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
