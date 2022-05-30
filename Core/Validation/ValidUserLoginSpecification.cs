using Core.Entities;
using System;
using System.Text.RegularExpressions;

namespace Core.Validation
{
    public class ValidUserLoginSpecification : ValidSpecification<User>
    {
        public override Func<User, bool> ToExpression()
        {
            return user => Regex.IsMatch(user.Login, @"^[a-zA-Z0-9]+$");
        }
    }
}
