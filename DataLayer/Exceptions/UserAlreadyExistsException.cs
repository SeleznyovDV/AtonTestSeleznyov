using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class UserAlreadyExistsException : ApiException
    {
        public UserAlreadyExistsException() : base(ExceptionCodes.UserAlreadyExist, "A user with this login already exists.")
        {
        }
    }
}
