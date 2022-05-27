using Data.Base;
using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.AuthorizationService;
using Data.Services.CurrentUserService;
using Data.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.CreateUserCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserDto>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;
        public CreateUserHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }

        public async Task<UserDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);
            
            if (currentUser.Admin == false)
                throw new AccessRightsException();

            var user = new User()
            {
                Login = request.dto.Login,
                Password = request.dto.Password,
                Name = request.dto.Name,
                Birthday = request.dto.Birthday,
                Admin = request.dto.Admin,
                Gender = request.dto.Gender
            };
            
            var validResult = new ValidateUserModel().Validate(user);
            if (validResult.Success == false)
                throw new UserValidationException(validResult.ErroMessage);
            
            if(await _db.User.FirstOrDefaultAsync(x=>x.Login == user.Login) != null)
                throw new UserAlreadyExistsException();

            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();
            
            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
