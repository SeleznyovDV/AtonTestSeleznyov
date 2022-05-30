namespace Data.Exceptions
{
    public class UserValidationException : ApiException
    {
        public UserValidationException(string error) : base(ExceptionCodes.UserValidationError, error)
        {
        }
    }
}
