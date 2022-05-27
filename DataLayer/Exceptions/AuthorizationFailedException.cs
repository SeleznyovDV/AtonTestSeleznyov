namespace Data.Exceptions
{
    public class AuthorizationFailedException: ApiException
    {
        public AuthorizationFailedException()
            :base(ExceptionCodes.AuthorizationFailed, "Login or password is invalid.")
        {
        }
    }
}
