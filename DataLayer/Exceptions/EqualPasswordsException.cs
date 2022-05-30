namespace Data.Exceptions
{
    public class EqualPasswordsException : ApiException
    {
        public EqualPasswordsException() : base(ExceptionCodes.EqualPasswords, "The new password must be different.")
        {
        }
    }
}
