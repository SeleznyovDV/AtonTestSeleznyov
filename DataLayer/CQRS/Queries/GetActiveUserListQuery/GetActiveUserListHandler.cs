using Data.CQRS.Dto.Response;
using Data.Exceptions;
using Data.Services.AuthorizationService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Queries.GetActiveUserListQuery
{
    public class GetActiveUserListHandler : IRequestHandler<GetActiveUserListRequest, IEnumerable<UserDto>>
    {
        private readonly IAuthorizationService _as;
        private readonly AppDbContext _db;
        public GetActiveUserListHandler(IAuthorizationService authorizationService, AppDbContext db)
        {
            _as = authorizationService;
            _db = db;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetActiveUserListRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _as.AuthorizeAsync(request.dto.CurrentUser.Login, request.dto.CurrentUser.Password);

            if (currentUser.Admin == false)
                throw new AccessRightsException();
            
            throw new NotImplementedException();
        }
    }
}
