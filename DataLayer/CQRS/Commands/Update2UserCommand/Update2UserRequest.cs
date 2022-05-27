using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Commands.Update2UserCommand
{
    public record Update2UserRequest(Update2UserDto dto) : IRequest<UserDto> { }
}
