using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using RemoteNotes.DAL.Contract.Provider;
using RemoteNotes.DAL.Contract.Repository;
using RemoteNotes.DAL.Core.Entity;

namespace RemoteNotes.DAL.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IDbProvider<MySqlConnection> service;

        public NoteRepository(IDbProvider<MySqlConnection> service)
        {
            this.service = service;
        }

        public void Create(Note item)
        {
            var sql =
                "INSERT INTO notes (AccountId, PublishTime, ModifyTime, Image, Text, Title) VALUES(@AccountId, @PublishTime, @ModifyTime, @Image, @Text, @Title)";

            var insertQuery = service.Connection.Execute(sql, new
            {
                AccountId = item.Account.Id,
                item.PublishTime,
                item.ModifyTime,
                item.Image,
                item.Text,
                item.Title
            });
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM notes WHERE Id = @Id";

            var deleteQuery = service.Connection.Execute(sql, new
            {
                Id = id
            });
        }

        public IEnumerable<Note> GetAll()
        {
            var sql = "SELECT * FROM notes n INNER JOIN accounts a ON a.Id = n.AccountId";

            var result = service.Connection.Query<Note, Account, Note>(sql, (n, a) =>
            {
                n.Account = a;
                return n;
            }).Distinct().ToList();

            return result;
        }

        public Note GetById(int id)
        {
            var sql = "SELECT * FROM notes n INNER JOIN accounts a ON a.Id = n.AccountId WHERE n.Id = @Id";

            var result = service.Connection.Query<Note, Account, Note>(sql, (n, a) =>
            {
                n.Account = a;
                return n;
            }, splitOn: "Id", param: new {Id = id}).Distinct().First();

            return result;
        }

        public void Update(Note item)
        {
            var sql =
                "UPDATE notes SET Title = @Title, Text = @Text, ModifyTime = @ModifyTime, Image = @Image, AccountId = @AccountId WHERE Id = @Id";

            var updateQuery = service.Connection.Execute(sql, new
            {
                item.Id,
                item.Title,
                item.Text,
                item.ModifyTime,
                item.Image,
                AccountId = item.Account.Id
            });
        }

        public List<Note> GetNotesByAccountId(int accountId)
        {
            var sql =
                "SELECT * FROM notes n INNER JOIN accounts a ON a.Id = n.AccountId WHERE n.AccountId = @AccountId";

            var result = service.Connection.Query<Note, Account, Note>(sql, (n, a) =>
            {
                n.Account = a;
                return n;
            }, splitOn: "Id", param: new {AccountId = accountId}).Distinct().ToList();

            return result;
        }
    }
}