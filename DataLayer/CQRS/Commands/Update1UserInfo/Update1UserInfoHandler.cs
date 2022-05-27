using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.AuthorizationService;
using Data.Services.CurrentUserService;
using Data.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.Update1UserInfo
{
    public class Update1UserInfoHandler : IRequestHandler<Update1UserInfoRequest, UserDto>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;
        public Update1UserInfoHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }
        public async Task<UserDto> Handle(Update1UserInfoRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);
            
            if (currentUser.Admin == false && currentUser.Login != request.dto.Login)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);
            
            if (user == null)
                throw new UserNotFoundException();
            
            if (user.IsDeleted())
                throw new RevokedUserException();

            user.Name = request.dto.Name;
            user.Birthday = request.dto.Birthday;
            user.Gender = request.dto.Gender;

            var validResult = new ValidateUserModel().Validate(user);
            
            if (validResult.Success == false)
                throw new UserValidationException(validResult.ErroMessage);

            _db.Update(user);
            await _db.SaveChangesAsync();

            return new UserDto(user.Login, user.Password,user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
