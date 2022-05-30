using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;

namespace Data.CQRS.Commands.Update1UserPassword
{
    [AccessRights("User")] 
    public record Update1UserPasswordRequest(Update1UserPasswordDto dto) : IRequest<UserDto> { }
}
