using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.AuthorizationService
{
    public class AuthorizationResult
    {
        public bool Success { get;}
        public User User { get;}
        public string Error { get; }
        public AuthorizationResult(bool success, User user)
        {
            Success = success;
            User = user;
        }

        public static AuthorizationResult Ok(User user)
        {
            return new AuthorizationResult(true, user);
        }
        public static AuthorizationResult Fail()
        {
            return new AuthorizationResult(false, null);
        }
    }
}
