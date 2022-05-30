using Core.BL.Dto.Response;
using Core.Exceptions;
using Core.Services.CurrentUserService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.BL.Queries.UserGetUserRequest
{
    public class UserGetUserHandler : IRequestHandler<UserGetUserRequest, UserDto>
    {
        private readonly AppDbContext _db;
        private ICurrentUserService _cus;
        public UserGetUserHandler(AppDbContext db, ICurrentUserService cus)
        {
            _db = db;
            _cus = cus;
        }
        public async Task<UserDto> Handle(UserGetUserRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var user = await _db.Users.FirstOrDefaultAsync(user => user.Login == _cus.GetUserLogin());

            if (user == null)
                throw new AccessRightsException();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
