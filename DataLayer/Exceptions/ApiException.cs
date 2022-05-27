using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public abstract class ApiException : Exception
    {
        public ExceptionCodes Code { get; }

        public ApiException(ExceptionCodes code, string errorMessage)
            :base(errorMessage)
        {
            Code = code;
        }
    }
}
