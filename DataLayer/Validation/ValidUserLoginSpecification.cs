using Data.Base;
using System;
using System.Text.RegularExpressions;

namespace Data.Validation
{
    public class ValidUserLoginSpecification : ValidSpecification<User>
    {
        public override Func<User, bool> ToExpression()
        {
            return user => Regex.IsMatch(user.Login, @"^[a-zA-Z0-9]+$");
        }
    }
}
