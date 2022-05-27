using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validation
{
    public class ValidUserResult
    {
        public bool Success => !_errors.Any();
        private Dictionary<string, string> _errors;
        public string ErroMessage => ToString();
        public ValidUserResult()
        {
            _errors = new Dictionary<string, string>();
        }
        public void AddValidationErorr(string field, string error)
        {
            _errors.Add(field,error);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The user fields do not meet the validation criteria:");
            foreach (var error in _errors)
            {
                sb.Append($" {error.Key}: {error.Value}");
            }
            
            return sb.ToString();
        }
    }
}
