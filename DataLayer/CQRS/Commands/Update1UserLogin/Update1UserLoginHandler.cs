using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.AuthorizationService;
using Data.Services.CurrentUserService;
using Data.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.Update1UserLogin
{
    public class Update1UserLoginHandler : IRequestHandler<Update1UserLoginRequest, UserDto>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;
        public Update1UserLoginHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }
        public async Task<UserDto> Handle(Update1UserLoginRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);

            if (currentUser.Admin == false && currentUser.Login != request.dto.Login)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (user.IsDeleted())
                throw new RevokedUserException();

            if (request.dto.Login == request.dto.NewLogin)
                throw new EqualLoginsException();

            if (await _db.User.FirstOrDefaultAsync(x => x.Login == request.dto.NewLogin) != null)
                throw new UserAlreadyExistsException();
            
            user.Login = request.dto.NewLogin;

            var validResult = new ValidateUserModel().Validate(user);

            if (validResult.Success == false)
                throw new UserValidationException(validResult.ToString());

            _db.Update(user);
            await _db.SaveChangesAsync();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
