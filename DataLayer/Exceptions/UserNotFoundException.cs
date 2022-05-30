namespace Data.Exceptions
{
    public class UserNotFoundException : ApiException
    {
        public UserNotFoundException() : base(ExceptionCodes.UserNotFound, "User dosn't exists.")
        {
        }
    }
}
