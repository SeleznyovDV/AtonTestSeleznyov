using Core.Exceptions;
using Core.Validation;
using System;

namespace Core.Entities
{
    public class User : AuditableEntity
    {
        public Guid Guid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Admin { get; set; }
        public User(string login, string password, string name, int gender, DateTime? birthday, bool admin)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            
            Login = login;
            Password = password;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Admin = admin;
        }
        public override bool Equals(object? obj)
        {
            if (obj is User user)
                return Guid == user.Guid;
            
            return false;
        }
        public override int GetHashCode()
        {
 
            return Guid.GetHashCode();
        }
        public void Validate()
        {
            var result = new ValidUserResult();

            if (new ValidUserLoginSpecification().IsSatisfiedBy(this) == false)
                result.AddValidationErorr(nameof(this.Login), "Use only Latin letters and numbers.");

            if (new ValidUserPasswordSpecification().IsSatisfiedBy(this) == false)
                result.AddValidationErorr(nameof(this.Password), "Use only Latin letters and numbers.");

            if (new ValidUserNameSpecification().IsSatisfiedBy(this) == false)
                result.AddValidationErorr(nameof(this.Name), "Use only Latin and Russian letters");

            if (new ValidUserGenderSpecification().IsSatisfiedBy(this) == false)
                result.AddValidationErorr(nameof(this.Gender), "Use the following numbers to select the gender: 0 - female, 1 - male, 2 - unknown.");

            if (result.Success == false)
                throw new UserValidationException(result.ErroMessage);
        }
    }
}
