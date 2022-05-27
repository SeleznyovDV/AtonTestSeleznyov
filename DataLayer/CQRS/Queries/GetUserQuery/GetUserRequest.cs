using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Queries.GetUserQuery
{
    public record GetUserRequest(GetUserDto dto) : IRequest<UserDto> { }
}
