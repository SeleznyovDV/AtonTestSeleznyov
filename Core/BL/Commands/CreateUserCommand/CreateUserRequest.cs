using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.BL.Commands.CreateUserCommand
{
    [AccessRights("Admin")]
    public record CreateUserRequest(CreateUserDto dto) : IRequest<UserDto> { }
}
