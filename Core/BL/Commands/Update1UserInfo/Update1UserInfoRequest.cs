using Core.BL;
using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.Bl.Commands.Update1UserInfo
{
    [AccessRights("User")]
    public record Update1UserInfoRequest(Update1UserInfoDto dto) : IRequest<UserDto> { }
}
