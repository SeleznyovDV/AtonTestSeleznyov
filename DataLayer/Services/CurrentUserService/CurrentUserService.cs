using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.CurrentUserService
{
    public class CurrentUserService : ICurrentUserService
    {
        public User _user;

        public CurrentUserService()
        {
            _user = null;
        }
        public string GetUserLogin()
        {
            if (_user == null)
                throw new InvalidOperationException();
            
            return _user.Login;
        }

        public void RemoveCurrentUser()
        {
            _user = null;
        }

        public void SetCurrentUser(User user)
        {
            _user = user;
        }
    }
}
