using CodeChallenge.Domain.Entities.Users;

namespace CodeChallenge.Infrastructure.Repositories
{
    public interface IUsersRepository
    {
        public Task<User> Get(string Username, string Password);
        public Task<int> Insert(User user);
        public Task<User> GetByEmail(string Email);
    }
}
