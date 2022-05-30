using Core.BL;
using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.Bl.Commands.Update1UserLogin
{
    [AccessRights("User")]
    public record Update1UserLoginRequest(Update1UserLoginDto dto) : IRequest<UserDto> { }
}
