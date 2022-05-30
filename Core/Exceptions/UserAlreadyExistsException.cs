namespace Core.Exceptions
{
    public class UserAlreadyExistsException : ApiException
    {
        public UserAlreadyExistsException() : base(ExceptionCodes.UserAlreadyExist, "A user with this login already exists.")
        {
        }
    }
}
