using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.AuthorizationService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Queries.GetUserQuery
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;

        public GetUserHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }
        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);
            
            if (currentUser.Admin == false)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
