using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class UserNotFoundException : ApiException
    {
        public UserNotFoundException() : base(ExceptionCodes.UserNotFound, "User dosn't exists.")
        {
        }
    }
}
