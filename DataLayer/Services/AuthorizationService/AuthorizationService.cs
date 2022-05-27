using Data.Base;
using Data.Exceptions;
using Data.Services.CurrentUserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.AuthorizationService
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly AppDbContext _db;
        private readonly ICurrentUserService _cus;
        public AuthorizationService(AppDbContext db, ICurrentUserService cus)
        {
            _db = db;
            _cus = cus;
        }

        public async Task<User> AuthorizeAsync(string login, string password)
        {            
            var user = await _db.User.FirstOrDefaultAsync(user => (user.Login == login && user.Password == password));
            
            if (user == null || user.RevokedBy != null)
                throw new AuthorizationFailedException();
            
            _cus.SetCurrentUser(user);
            return user;
        }

    }
}
