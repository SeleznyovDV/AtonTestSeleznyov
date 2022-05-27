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

namespace Data.CQRS.Commands.Update2UserCommand
{
    public class Update2UserHandler : IRequestHandler<Update2UserRequest, UserDto>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;
        public Update2UserHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }
        public async Task<UserDto> Handle(Update2UserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);

            if (currentUser.Admin == false)
                throw new AccessRightsException();

            var user = await _db.User.FirstOrDefaultAsync(user => user.Login == request.dto.Login);

            if (user == null)
                throw new UserNotFoundException();

            if (user.RevokedBy == null)
                throw new UnRevokedUserException();

            user.UnRevoke();
            _db.Update(user);
            await _db.SaveChangesAsync();

            return new UserDto(user.Login, user.Password, user.Name, user.Gender, user.Birthday, user.RevokedBy);
        }
    }
}
