using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CQRS.Dto.Response
{
    public class UserDto
    {
        public string Login { get; }
        public string Name { get; }
        public string Password { get; }
        public string Gender { get; }
        public DateTime? Birthday { get; }
        public string Status { get; }
        public UserDto(string login,string password, string name, int gender, DateTime? birthday, string revokedBy)
        {
            var genderEnum = (GenderEnum) gender;
            
            Login = login;
            Password = password;
            Gender = genderEnum.ToString();
            Birthday = birthday;

            if (revokedBy == null)
                Status = RevokedStatus.Active.ToString();
            else
                Status = RevokedStatus.Revoked.ToString();
        }
    }
}
