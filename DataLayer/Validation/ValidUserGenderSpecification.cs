using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
