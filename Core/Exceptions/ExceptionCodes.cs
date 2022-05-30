namespace Core.Exceptions
{
    public enum ExceptionCodes
    {
        AuthorizationFailed = 100,
        NoAccessRights = 101,
        UserValidationError = 102,
        UserAlreadyExist = 103,
        UserNotFound = 104,
        RevokedUser = 105,
        UnRevokedUser = 106,
        EqualPasswords = 107,
        EqualLogins = 108,
        SelfDeleting = 109,
    }
}
