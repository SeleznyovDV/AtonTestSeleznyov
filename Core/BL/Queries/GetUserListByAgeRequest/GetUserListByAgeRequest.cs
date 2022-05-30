using Core.BL;
using Core.BL.Dto.Response;
using MediatR;
using System.Collections.Generic;

namespace Core.Bl.Queries.GetUserListByAgeRequest
{
    [AccessRights("Admin")]
    public record GetUserListByAgeRequest(int age) : IRequest<IEnumerable<UserDto>> {}

}
