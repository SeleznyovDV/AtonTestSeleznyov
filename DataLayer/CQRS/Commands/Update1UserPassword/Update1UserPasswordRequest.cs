using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.Update1UserPassword
{
    public record Update1UserPasswordRequest(Update1UserPasswordDto dto) : IRequest<UserDto> { }
}
