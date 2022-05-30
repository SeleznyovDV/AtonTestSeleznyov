using Core.BL.Dto.Response;
using Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Bl.Queries.GetUserListByAgeRequest
{
    public class GetUserListByAgeHandler : IRequestHandler<GetUserListByAgeRequest, IEnumerable<UserDto>>
    {
        private readonly AppDbContext _db;
        public GetUserListByAgeHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUserListByAgeRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var today = DateTime.Today;
            
            var userList = _db.Users.Where(user =>
                (((today.Year * 100 + today.Month) * 100 + today.Day) 
                - ((user.Birthday.Value.Year * 100 + user.Birthday.Value.Month) * 100 + user.Birthday.Value.Day))
                /10000 >= request.age);

            if (!userList.Any())
                throw new UserNotFoundException();

            return userList.Select(x => new UserDto(x.Login, x.Password, x.Name, x.Gender, x.Birthday, x.RevokedBy));
        }
    }
}
