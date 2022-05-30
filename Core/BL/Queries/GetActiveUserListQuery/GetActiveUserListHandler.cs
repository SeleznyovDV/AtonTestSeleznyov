using Core.BL.Dto.Response;
using Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Bl.Queries.GetActiveUserListQuery
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

            var userList = _db.Users.Where(user => user.RevokedBy == null).OrderBy(user => user.CreateOn).AsEnumerable();

            if (!userList.Any())
                throw new UserNotFoundException();
            
            return userList.Select(x => new UserDto(x.Login, x.Password, x.Name, x.Gender, x.Birthday, x.RevokedBy)); 
        }
    }
}
