using System.Linq;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.DAL.Repository;
using Xunit;

namespace RemoteNotes.DAL.Tests
{
    public class AccountRepositoryTests
    {
        public MySqlProvider service;

        public AccountRepository SetAccountRepository()
        {
            service = new MySqlProvider(
                "server=localhost;UserId=root;Password=1234;database=remotenotesIntegrationTest;allow zero datetime=yes;Allow User Variables = True");
            var hold = new AccountRepository(service);
            return hold;
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestCreate(int id, string firstName)
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = id, FirstName = firstName};
            accountRepository.Create(account);
            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == firstName).FirstOrDefault();
            Assert.Equal(account.FirstName, holdAccount.FirstName);
            accountRepository.Delete(holdAccount.Id);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestCreateFailure(int id, string firstName)
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = id, FirstName = firstName};
            accountRepository.Create(account);
            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == firstName).FirstOrDefault();
            Assert.NotEqual(account.FirstName, "not correct name");
            accountRepository.Delete(holdAccount.Id);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestDelete(int id, string firstName)
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = id, FirstName = firstName};
            accountRepository.Create(account);

            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == firstName).FirstOrDefault();
            accountRepository.Delete(holdAccount.Id);
            Assert.Null(accountRepository.GetById(holdAccount.Id));
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestDeleteFailure(int id, string firstName)
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = id, FirstName = firstName};
            accountRepository.Create(account);

            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == firstName).FirstOrDefault();
            accountRepository.Delete(-1);
            Assert.NotNull(accountRepository.GetById(holdAccount.Id));
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestUpdate(int id, string firstName)
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = id, FirstName = firstName};
            accountRepository.Create(account);
            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == firstName).FirstOrDefault();
            holdAccount.FirstName = "UpdatedName";
            accountRepository.Update(holdAccount);
            var holdUpdatedAccount = holdAllAccounts.Where(x => x.FirstName == holdAccount.FirstName).FirstOrDefault();
            Assert.NotEqual(account.FirstName, holdUpdatedAccount.FirstName);
            accountRepository.Delete(holdAccount.Id);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestUpdateFailure(int id, string firstName)
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = id, FirstName = firstName};
            accountRepository.Create(account);
            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == firstName).FirstOrDefault();
            //holdAccount.FirstName = "UpdatedName";
            accountRepository.Update(holdAccount);
            var holdUpdatedAccount = holdAllAccounts.Where(x => x.FirstName == holdAccount.FirstName).FirstOrDefault();
            Assert.Equal(account.FirstName, holdUpdatedAccount.FirstName);
            accountRepository.Delete(holdAccount.Id);
        }
    }
}