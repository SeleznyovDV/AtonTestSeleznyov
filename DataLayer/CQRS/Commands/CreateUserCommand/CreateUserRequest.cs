using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;

namespace Data.CQRS.Commands.CreateUserCommand
{
    [AccessRights("Admin")]
    public record CreateUserRequest(CreateUserDto dto) : IRequest<UserDto> { }
}
