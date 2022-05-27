using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Validation
{
    public class ValidUserPasswordSpecification : ValidSpecification<User>
    {
        public override Func<User, bool> ToExpression()
        {
            return user => Regex.IsMatch(user.Password, @"^[a-zA-Z0-9]+$");
        }
    }
}
