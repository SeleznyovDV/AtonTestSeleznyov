using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class User : AuditableEntity
    {
        public Guid Guid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Admin { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is User user)
                return Login == user.Login;
            
            return false;
        }
        public override int GetHashCode()
        {
 
            return Login.GetHashCode();
        }
    }
}
