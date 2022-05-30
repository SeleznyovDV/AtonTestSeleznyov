using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;

namespace Data.CQRS.Commands.DeleteUserCommand
{
    [AccessRights("Admin")]
    public record DeleteUserRequest(DeleteUserDto dto) : IRequest<UserDto> { }
}
