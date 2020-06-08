using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using RemoteNotes.DAL.Contract.Provider;
using RemoteNotes.DAL.Contract.Repository;
using RemoteNotes.DAL.Core.Entity;

namespace RemoteNotes.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbProvider<MySqlConnection> service;

        public UserRepository(IDbProvider<MySqlConnection> service)
        {
            this.service = service;
        }

        public void Create(User item)
        {
            var sql =
                "INSERT INTO users (AccountId, Login, Password, IsActive, AccessLevel) VALUES(@AccountId, @Login, @Password, @IsActive, @AccessLevel)";

            var insertQuery = service.Connection.Execute(sql, new
            {
                AccountId = item.Account.Id,
                item.Login,
                item.Password,
                item.IsActive,
                item.AccessLevel
            });
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM users WHERE Id = @Id";

            var deleteQuery = service.Connection.Execute(sql, new
            {
                Id = id
            });
        }

        public IEnumerable<User> GetAll()
        {
            var sql = "SELECT * FROM users u INNER JOIN accounts a ON a.Id = u.AccountId";

            var result = service.Connection.Query<User, Account, User>(sql, (u, a) =>
            {
                u.Account = a;
                return u;
            }).Distinct().ToList();

            return result;
        }

        public User GetById(int id)
        {
            var sql = "SELECT * FROM users u INNER JOIN accounts a ON a.Id = u.AccountId WHERE u.Id = @Id";

            var result = service.Connection.Query<User, Account, User>(sql, (u, a) =>
            {
                u.Account = a;
                return u;
            }, splitOn: "Id", param: new {Id = id}).Distinct().First();

            return result;
        }

        public void Update(User item)
        {
            var sql =
                "UPDATE users SET AccountId = @AccountId, Login = @Login, Password = @Password, IsActive = @IsActive, AccessLevel = @AccessLevel WHERE Id = @Id";

            var updateQuery = service.Connection.Execute(sql, new
            {
                AccountId = item.Account.Id,
                item.Login,
                item.Password,
                item.IsActive,
                item.AccessLevel,
                item.Id
            });
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            var sql =
                "SELECT * FROM users u INNER JOIN accounts a ON a.Id = u.AccountId WHERE Login = @Login and Password = @Password";

            var result = service.Connection.Query<User, Account, User>(sql, (u, a) =>
            {
                u.Account = a;
                return u;
            }, splitOn: "Id", param: new {Login = login, Password = password}).Distinct().First();

            return result;
        }

        public User GetUserByLogin(string login)
        {
            var sql = "SELECT * FROM users u INNER JOIN accounts a ON a.Id = u.AccountId WHERE Login = @Login";

            var result = service.Connection.Query<User, Account, User>(sql, (u, a) =>
            {
                u.Account = a;
                return u;
            }, splitOn: "Id", param: new {Login = login}).Distinct().First();

            return result;
        }

        public void ChangeUserStatusById(int id, bool status)
        {
            var sql = "UPDATE users SET IsActive = @IsActive WHERE Id = @Id";

            var query = service.Connection.Execute(sql, new
            {
                Id = id,
                IsActive = status
            });
        }

        public User GetLastUserId()
        {
            var sql = "SELECT * FROM users u INNER JOIN accounts a ON a.Id = u.AccountId ORDER BY u.Id DESC LIMIT 1";

            var result = service.Connection.Query<User, Account, User>(sql, (u, a) =>
            {
                u.Account = a;
                return u;
            }, splitOn: "Id", param: new {}).Distinct().First();

            return result;
        }

        public void CascadeDeleteUser(int id)
        {
            var sql = "DELETE users, accounts FROM users INNER JOIN accounts ON users.AccountId = accounts.id WHERE users.id = @Id";

            var deleteQuery = service.Connection.Execute(sql, new
            {
                Id = id
            });
        }
    }
}