namespace Core.Exceptions
{
    public class UnRevokedUserException : ApiException
    {
        public UnRevokedUserException() : base(ExceptionCodes.UnRevokedUser, "The user isn't revoked!")
        {
        }
    }
}
