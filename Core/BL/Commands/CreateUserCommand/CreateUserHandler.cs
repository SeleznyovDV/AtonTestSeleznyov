using Core.BL.Dto.Response;
using Core.Entities;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.BL.Commands.CreateUserCommand
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

            var dto = request.dto;
            var user = new User(dto.Login, dto.Password, dto.Name, dto.Gender, dto.Birthday, dto.Admin);
                    
            if(await _db.Users.FirstOrDefaultAsync(x=>x.Login == user.Login) != null)
                throw new UserAlreadyExistsException();

            user.Validate();

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            
            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
