using Data.CQRS.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Queries.GetUserQuery
{
    [AccessRights("User")]
    public record UserGetUserRequest() : IRequest<UserDto> { }
}
