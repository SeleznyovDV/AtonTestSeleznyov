using Data.CQRS.Commands.CreateUserCommand;
using Data.CQRS.Commands.DeleteUserCommand;
using Data.CQRS.Commands.Update1UserInfo;
using Data.CQRS.Commands.Update1UserLogin;
using Data.CQRS.Commands.Update1UserPassword;
using Data.CQRS.Commands.Update2UserCommand;
using Data.CQRS.Dto.Request;
using Data.CQRS.Dto.Response;
using Data.CQRS.Queries.GetUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Wep.App.Controllers.Base;
using Wep.App.Dto.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApplicationController
    {
        public UserController(IMediator mediator)
            :base(mediator)
        {

        }
        
        [HttpPost("create")]
        public async Task<ApiResponse<UserDto>> CreateUser([FromBody] CreateUserDto request,CancellationToken token)
        {
            var result = await Mediator.Send(new CreateUserRequest(request), token);
            
            return Ok(result);
        }
        
        [HttpPut("update-1")]
        public async Task<ApiResponse<UserDto>> Update1UserInfo([FromBody] Update1UserInfoDto request, CancellationToken token)
        {
            var result = await Mediator.Send(new Update1UserInfoRequest(request), token);

            return Ok(result);
        }
        
        [HttpPut("update-1/password")]
        public async Task<ApiResponse<UserDto>> Update1UserPassword([FromBody] Update1UserPasswordDto request, CancellationToken token)
        {
            var result = await Mediator.Send(new Update1UserPasswordRequest(request), token);

            return Ok(result);
        }

        [HttpPut("update-1/login")]
        public async Task<ApiResponse<UserDto>> Update1UserLogin([FromBody] Update1UserLoginDto request, CancellationToken token)
        {
            var result = await Mediator.Send(new Update1UserLoginRequest(request), token);

            return Ok(result);
        }
        
        [HttpPost("read/{login}")]
        public async Task<ApiResponse<UserDto>> GetUser(string login,[FromBody] CurrentUserDto user, CancellationToken token)
        {
            var result = await Mediator.Send(new GetUserRequest(new GetUserDto { Login = login, CurrentUser = user}), token);

            return Ok(result);
        }
        
        [HttpDelete("delete")]
        public async Task<ApiResponse<UserDto>> DeleteUser([FromBody] DeleteUserDto request, CancellationToken token)
        {
            var result = await Mediator.Send(new DeleteUserRequest(request), token);

            return Ok(result);
        }

        [HttpPut("update-2")]
        public async Task<ApiResponse<UserDto>> Update2User([FromBody] Update2UserDto request, CancellationToken token)
        {
            var result = await Mediator.Send(new Update2UserRequest(request), token);

            return Ok(result);
        }
    }
}
