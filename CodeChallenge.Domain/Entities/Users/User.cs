using CodeChallenge.Domain.Enums;

namespace CodeChallenge.Domain.Entities.Users
{
    public class User
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public Gender Gender { get; set; }
    }
}
