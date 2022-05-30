namespace Core.Exceptions
{
    public class SelfDeletingException : ApiException
    {
        public SelfDeletingException() : base(ExceptionCodes.SelfDeleting, "You can't delete yourself.")
        {
        }
    }
}
