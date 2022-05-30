using Core.BL;
using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.Bl.Queries.AdminGetUserQuery
{
    [AccessRights("Admin")]
    public record AdminGetUserRequest(GetUserDto dto) : IRequest<UserDto> { }
}
