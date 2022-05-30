using Core.BL.Dto.Response;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Bl.Queries.AdminGetUserQuery
{
    public class AdminGetUserHandler : IRequestHandler<AdminGetUserRequest, UserDto>
    {
        private readonly AppDbContext _db;

        public AdminGetUserHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<UserDto> Handle(AdminGetUserRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _db.Users.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
