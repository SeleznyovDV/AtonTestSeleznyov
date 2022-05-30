using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;
using System.Collections.Generic;

namespace Data.CQRS.Queries.GetActiveUserListQuery
{
    [AccessRights("Admin")]
    public record GetActiveUserListRequest() : IRequest<IEnumerable<UserDto>> { }
}
