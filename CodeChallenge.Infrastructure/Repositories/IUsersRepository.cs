using CodeChallenge.Domain.Entities.Users;

namespace CodeChallenge.Infrastructure.Repositories
{
    public interface IUsersRepository
    {
        public Task<User> Get(string Username, string Password);
        public Task<List<User>> GetAll();
        public Task<User> GetByEmail(string Email);
        public Task<int> Insert(User user);
        public Task<int> Delete(string Email);
        public Task<int> Update(User Email);

    }
}
