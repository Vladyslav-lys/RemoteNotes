using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using RemoteNotes.DAL.Contract.Provider;
using RemoteNotes.DAL.Contract.Repository;
using RemoteNotes.DAL.Core.Entity;

namespace RemoteNotes.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbProvider<MySqlConnection> service;

        public AccountRepository(IDbProvider<MySqlConnection> service)
        {
            this.service = service;
        }

        public void Create(Account item)
        {
            var sql =
                "INSERT INTO accounts (CreateTime, ModifyTime, Photo, FirstName, LastName, Nickname, Birthday, Email) VALUES(@CreateTime, @ModifyTime, @Photo, @FirstName, @LastName, @Nickname, @Birthday, @Email); ";

            var insertQuery = service.Connection.Execute(sql, new
            {
                item.CreateTime,
                item.ModifyTime,
                item.Photo,
                item.FirstName,
                item.LastName,
                item.Nickname,
                item.Birthday,
                item.Email
            });
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM accounts WHERE Id = @Id";

            var deleteQuery = service.Connection.Execute(sql, new
            {
                Id = id
            });
        }

        public Account GetAccountLastId()
        {
            var sql = "SELECT * FROM accounts ORDER BY Id DESC LIMIT 1";

            var result = service.Connection.Query<Account>(sql, new { }).Distinct().First();

            return result;
        }

        public IEnumerable<Account> GetAll()
        {
            var sql = "SELECT * FROM accounts";

            var result = service.Connection.Query<Account>(sql).Distinct().ToList();

            return result;
        }

        public Account GetById(int id)
        {
            var sql = "SELECT * FROM accounts WHERE Id = @Id";

            var result = service.Connection.Query<Account>(sql, new {Id = id}).Distinct().First();

            return result;
        }

        public void Update(Account item)
        {
            var sql =
                "UPDATE accounts SET ModifyTime = @ModifyTime, Photo = @Photo, FirstName = @FirstName, LastName = @LastName, Nickname = @Nickname, Birthday = @Birthday, Email = @Email WHERE Id = @Id";

            var updateQuery = service.Connection.Execute(sql, new
            {
                item.ModifyTime,
                item.Photo,
                item.FirstName,
                item.LastName,
                item.Nickname,
                item.Birthday,
                item.Email,
                item.Id
            });
        }
    }
}