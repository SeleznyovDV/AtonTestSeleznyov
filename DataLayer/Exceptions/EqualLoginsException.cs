namespace Data.Exceptions
{
    public class EqualLoginsException : ApiException
    {
        public EqualLoginsException() : base(ExceptionCodes.EqualLogins, "The new login must be different.")
        {
        }
    }
}
