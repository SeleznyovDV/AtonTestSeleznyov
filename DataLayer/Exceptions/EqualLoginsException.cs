using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class EqualLoginsException : ApiException
    {
        public EqualLoginsException() : base(ExceptionCodes.EqualLogins, "The new login must be different.")
        {
        }
    }
}
