using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Shared.Authentication
{
    public class UserSignupDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public User ToUser()
        {
            var user = new User()
            {
                Email = this.Email,
                Password = this.Password,
                Name = this.Name,
                Age = this.Age,
                Gender = this.Gender
            };

            return user;

        }
    }
}
