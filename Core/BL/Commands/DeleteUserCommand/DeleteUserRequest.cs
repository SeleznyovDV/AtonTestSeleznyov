using Core.BL;
using Core.BL.Dto.Request;
using Core.BL.Dto.Response;
using MediatR;

namespace Core.Bl.Commands.DeleteUserCommand
{
    [AccessRights("Admin")]
    public record DeleteUserRequest(DeleteUserDto dto) : IRequest<UserDto> { }
}
