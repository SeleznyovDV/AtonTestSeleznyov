namespace Data.Exceptions
{
    public class RevokedUserException : ApiException
    {
        public RevokedUserException() : base(ExceptionCodes.RevokedUser, "The user is revoked.")
        {
        }
    }
}
