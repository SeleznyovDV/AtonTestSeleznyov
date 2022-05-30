using Data.CQRS.Dto.Request;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Data.Services.CurrentUserService
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAcessor;
        private Lazy<CurrentUserDto> _currentUser;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAcessor = contextAccessor;
            _currentUser = new Lazy<CurrentUserDto>(() => CreateCurrentUser());
        }

        public string GetUserLogin()
        {
            return _currentUser.Value.Login;
        }
        public CurrentUserDto GetUser() => _currentUser.Value;
        private CurrentUserDto CreateCurrentUser() 
        {
            var context = _contextAcessor.HttpContext;

            var headers = context.Request.Headers;

            var (key1, login) = headers.FirstOrDefault(x => x.Key == "login");
            
            var (key2, password) = headers.FirstOrDefault(x => x.Key == "password");

            return new CurrentUserDto { Login = login, Password = password };

        }
    }
}
