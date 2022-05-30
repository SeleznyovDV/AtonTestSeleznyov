namespace Data.Exceptions
{
    public class AccessRightsException : ApiException
    {
        public AccessRightsException()
            :base(ExceptionCodes.NoAccessRights, "Not enough access rights")
        { 
        }
    }
}
