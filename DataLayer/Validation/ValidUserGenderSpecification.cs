using Data.Base;
using System;

namespace Data.Validation
{
    public class ValidUserGenderSpecification : ValidSpecification<User>
    {
        public override Func<User, bool> ToExpression()
        {
            return user => (0 <= user.Gender && user.Gender <= 2);
        }
    }

}
