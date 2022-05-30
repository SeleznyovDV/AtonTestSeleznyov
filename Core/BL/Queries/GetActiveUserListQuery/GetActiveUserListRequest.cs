using Core.BL;
using Core.BL.Dto.Response;
using MediatR;
using System.Collections.Generic;

namespace Core.Bl.Queries.GetActiveUserListQuery
{
    [AccessRights("Admin")]
    public record GetActiveUserListRequest() : IRequest<IEnumerable<UserDto>> { }
}
