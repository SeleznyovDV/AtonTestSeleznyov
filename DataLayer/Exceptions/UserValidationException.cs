using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class UserValidationException : ApiException
    {
        public UserValidationException(string error) : base(ExceptionCodes.UserValidationError, error)
        {
        }
    }
}
