using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class UnRevokedUserException : ApiException
    {
        public UnRevokedUserException() : base(ExceptionCodes.UnRevokedUser, "The user isn't revoked!")
        {
        }
    }
}
