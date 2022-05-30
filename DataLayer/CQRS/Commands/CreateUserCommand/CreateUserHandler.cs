using Data.Base;
using Data.CQRS.Dto.Response;
using Data.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.CreateUserCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserDto>
    {
        private readonly AppDbContext _db;
        public CreateUserHandler( AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = new User()
            {
                Login = request.dto.Login,
                Password = request.dto.Password,
                Name = request.dto.Name,
                Birthday = request.dto.Birthday,
                Admin = request.dto.Admin,
                Gender = request.dto.Gender
            };
                    
            if(await _db.User.FirstOrDefaultAsync(x=>x.Login == user.Login) != null)
                throw new UserAlreadyExistsException();

            user.Validate();

            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();
            
            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
