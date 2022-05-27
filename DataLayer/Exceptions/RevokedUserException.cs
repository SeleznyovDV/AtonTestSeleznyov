using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class RevokedUserException : ApiException
    {
        public RevokedUserException() : base(ExceptionCodes.RevokedUser, "The user is revoked.")
        {
        }
    }
}
