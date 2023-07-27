using CodeChallenge.Domain.Enums;

namespace CodeChallenge.Domain.Entities.Users
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
