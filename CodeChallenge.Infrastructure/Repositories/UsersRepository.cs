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
        public async Task<User> Get(string Username, string Password)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = "SELECT  * FROM users WHERE Username=@Username and Password=@Password";

            var user = await connection.QueryAsync<User>(SQL, new {Username, Password});

            return user.FirstOrDefault();
        }

        public async Task<int> Insert(User user)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));

            var SQL = @"Insert into `users`(`Username`,`Password`,`Name`,`Email`,`Age`,`Gender`) 
                        values (@Username, @Password,@Name,@Email,@Age,@Gender)";

            var result = await connection.ExecuteAsync(SQL, user);

            return result;
        }
    }
}
