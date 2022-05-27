using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.CurrentUserService
{
    public interface ICurrentUserService
    {
        public void SetCurrentUser(User user);
        public void RemoveCurrentUser();
        public string GetUserLogin();
    }
}
