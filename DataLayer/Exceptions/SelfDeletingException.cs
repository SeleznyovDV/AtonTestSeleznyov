using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class SelfDeletingException : ApiException
    {
        public SelfDeletingException() : base(ExceptionCodes.SelfDeleting, "You can't delete yourself.")
        {
        }
    }
}
