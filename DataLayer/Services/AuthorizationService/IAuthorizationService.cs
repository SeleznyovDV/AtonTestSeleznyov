using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.AuthorizationService
{
    public interface IAuthorizationService
    {
        public Task<User> AuthorizeAsync(string login, string password);
    }
}
