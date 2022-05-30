using Core.BL;
using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.Bl.Commands.Update2UserCommand
{
    [AccessRights("Admin")]
    public record Update2UserRequest(Update2UserDto dto) : IRequest<UserDto> { }
}
