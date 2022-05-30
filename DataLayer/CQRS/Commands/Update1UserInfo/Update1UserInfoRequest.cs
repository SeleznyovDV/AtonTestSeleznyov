using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;

namespace Data.CQRS.Commands.Update1UserInfo
{
    [AccessRights("User")]
    public record Update1UserInfoRequest(Update1UserInfoDto dto) : IRequest<UserDto> { }
}
