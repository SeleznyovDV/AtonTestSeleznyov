using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Validation
{
    public class ValidUserNameSpecification : ValidSpecification<User>
    {
        public override Func<User, bool> ToExpression()
        {
            return user => Regex.IsMatch(user.Name, @"^[a-zA-Zа-яА-Я]+$");
        }
    }
}
