using CodeChallenge.Domain.Entities.Users;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _configuration;

        public UsersRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public async Task<User> Get(string Email, string Password)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = "SELECT  * FROM users WHERE Email=@Email and Password=@Password";

            var user = await connection.QueryAsync<User>(SQL, new { Email, Password});

            return user.FirstOrDefault();
        }

        public async Task<int> Insert(User user)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = @"Insert into `users`(`Email`,`Password`,`Name`,`Age`,`Gender`) 
                        values (@Email,@Password,@Name,@Age,@Gender)";

            var result = await connection.ExecuteAsync(SQL, user);

            return result;
        }

        public async Task<User> GetByEmail(string Email)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = "SELECT  * FROM users WHERE Email=@Email";

            var user = await connection.QueryAsync<User>(SQL, new { Email});

            return user.FirstOrDefault();
        }

        public async Task<List<User>> GetAll()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = "SELECT  * FROM users";

            var users = await connection.QueryAsync<User>(SQL);

            return users.ToList();
        }

        public async Task<int> Delete(string Email)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = @"DELETE FROM users WHERE Email = @Email";

            var result = await connection.ExecuteAsync(SQL, new { Email });

            return result;
        }

        public async Task<int> Update(User user)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = @"UPDATE users SET Password=@Password,Name=@Name,Age=@Age,Gender=@Gender WHERE Email = @Email";

            var result = await connection.ExecuteAsync(SQL, user);

            return result;
        }
    }
}
