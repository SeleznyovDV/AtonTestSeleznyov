using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Queries.GetActiveUserListQuery
{
    public record GetActiveUserListRequest(GetActiveUserListDto dto) : IRequest<IEnumerable<UserDto>> { }
}
