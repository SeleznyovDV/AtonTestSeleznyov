using Core.BL;
using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.Bl.Commands.Update1UserPassword
{
    [AccessRights("User")] 
    public record Update1UserPasswordRequest(Update1UserPasswordDto dto) : IRequest<UserDto> { }
}
