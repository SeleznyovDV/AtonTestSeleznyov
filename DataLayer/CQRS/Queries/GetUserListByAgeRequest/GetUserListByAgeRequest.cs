using Data.CQRS.Dto.Response;
using MediatR;
using System.Collections.Generic;

namespace Data.CQRS.Queries.GetUserListByAgeRequest
{
    [AccessRights("Admin")]
    public record GetUserListByAgeRequest(int age) : IRequest<IEnumerable<UserDto>> {}

}
