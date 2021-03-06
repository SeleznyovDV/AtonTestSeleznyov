using System;

namespace Core.Exceptions
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
