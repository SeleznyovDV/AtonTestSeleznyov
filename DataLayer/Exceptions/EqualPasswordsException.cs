using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class EqualPasswordsException : ApiException
    {
        public EqualPasswordsException() : base(ExceptionCodes.EqualPasswords, "The new password must be different.")
        {
        }
    }
}
