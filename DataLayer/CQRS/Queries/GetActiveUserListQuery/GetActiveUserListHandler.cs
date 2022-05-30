using Data.CQRS.Dto.Response;
using Data.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.CQRS.Queries.GetActiveUserListQuery
{
    public class GetActiveUserListHandler : IRequestHandler<GetActiveUserListRequest, IEnumerable<UserDto>>
    {
        private readonly AppDbContext _db;
        public GetActiveUserListHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetActiveUserListRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var userList = _db.User.Where(user => user.RevokedBy == null).AsEnumerable().OrderBy(user => user.CreateOn);

            if (!userList.Any())
                throw new UserNotFoundException();
            
            return userList.Select(x => new UserDto(x.Login, x.Password, x.Name, x.Gender, x.Birthday, x.RevokedBy)); 
        }
    }
}
