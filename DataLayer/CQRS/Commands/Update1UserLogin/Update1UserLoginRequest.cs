using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;

namespace Data.CQRS.Commands.Update1UserLogin
{
    [AccessRights("User")]
    public record Update1UserLoginRequest(Update1UserLoginDto dto) : IRequest<UserDto> { }
}
