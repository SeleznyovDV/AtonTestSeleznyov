using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;

namespace Data.CQRS.Commands.Update2UserCommand
{
    [AccessRights("Admin")]
    public record Update2UserRequest(Update2UserDto dto) : IRequest<UserDto> { }
}
