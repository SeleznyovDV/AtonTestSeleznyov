using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validation
{
    public class ValidateUserModel
    {
        public ValidUserResult Validate(User user)
        {
            var result = new ValidUserResult();
            
            if (new ValidUserLoginSpecification().IsSatisfiedBy(user) == false)
                result.AddValidationErorr(nameof(user.Login), "Use only Latin letters and numbers.");

            if (new ValidUserPasswordSpecification().IsSatisfiedBy(user) == false)
                result.AddValidationErorr(nameof(user.Password), "Use only Latin letters and numbers.");

            if (new ValidUserNameSpecification().IsSatisfiedBy(user) == false)
                result.AddValidationErorr(nameof(user.Name), "Use only Latin and Russian letters");

            if(new ValidUserGenderSpecification().IsSatisfiedBy(user) == false)
                result.AddValidationErorr(nameof(user.Gender), "Use the following numbers to select the gender: 0 - female, 1 - male, 2 - unknown.");

            return result;
        }
    }
}
