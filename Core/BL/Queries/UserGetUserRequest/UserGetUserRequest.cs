using Core.BL.Dto.Response;
using MediatR;

namespace Core.BL.Queries.UserGetUserRequest
{
    [AccessRights("User")]
    public record UserGetUserRequest() : IRequest<UserDto> { }
}
