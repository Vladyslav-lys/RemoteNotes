using System.Linq;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.DAL.Repository;
using Xunit;

namespace RemoteNotes.DAL.Tests
{
    public class UserReposioryTests
    {
        public MySqlProvider service;

        public AccountRepository SetAccountRepository()
        {
            service = new MySqlProvider(
                "server=localhost;UserId=root;Password=1234;database=remotenotesIntegrationTest;allow zero datetime=yes;Allow User Variables=True;");
            var hold = new AccountRepository(service);
            return hold;
        }

        public Account GetAccountHelper()
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = 0, FirstName = "testAccount"};
            accountRepository.Create(account);
            var holdAllAccounts = accountRepository.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == "testAccount").FirstOrDefault();
            return holdAccount;
        }

        public void DeleteAccountHelper(Account account)
        {
            // AccountRepository accountRepository = SetAccountRepository();

            // accountRepository.Delete(account.Id);
        }

        public UserRepository SetUserRepository()
        {
            service = new MySqlProvider(
                "server=localhost;UserId=root;Password=1234;database=remotenotesIntegrationTest;allow zero datetime=yes;Allow User Variables=True;");
            var hold = new UserRepository(service);
            return hold;
        }

        [Theory]
        [InlineData(0, "testContent1")]
        [InlineData(1, "testContent2")]
        [InlineData(2, "testContent3")]
        public void TestCreate(int id, string content)
        {
            var account = GetAccountHelper();
            var accountRepository = SetUserRepository();
            var user = new User {Id = id, Login = content, Account = account};
            accountRepository.Create(user);
            var holdAllNotes = accountRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Login == content).FirstOrDefault();
            Assert.Equal(user.Login, holdNote.Login);
            accountRepository.Delete(holdNote.Id);
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestCreateFailure(int id, string content)
        {
            var account = GetAccountHelper();
            var accountRepository = SetUserRepository();
            var user = new User {Id = id, Login = content, Account = account};
            accountRepository.Create(user);
            var holdAllNotes = accountRepository.GetAll();
            var holdForDelete = holdAllNotes.Where(x => x.Login == content).FirstOrDefault();
            accountRepository.Delete(holdForDelete.Id);
            var holdNote = holdAllNotes.Where(x => x.Login == content).FirstOrDefault();
            Assert.NotEqual(account.FirstName, "not correct name");
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestDelete(int id, string content)
        {
            var account = GetAccountHelper();
            var userRepository = SetUserRepository();
            var user = new User {Id = id, Login = content, Account = account};
            userRepository.Create(user);

            var holdAllNotes = userRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Login == content).FirstOrDefault();
            userRepository.Delete(holdNote.Id);
            Assert.Null(userRepository.GetById(holdNote.Id));
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestDeleteFailure(int id, string content)
        {
            var account = GetAccountHelper();
            var userRepository = SetUserRepository();
            var user = new User {Id = id, Login = content, Account = account};
            userRepository.Create(user);

            var holdAllNotes = userRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Login == content).FirstOrDefault();
            userRepository.Delete(-1);
            Assert.NotNull(userRepository.GetById(holdNote.Id));
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestUpdate(int id, string content)
        {
            var account = GetAccountHelper();
            var userRepository = SetUserRepository();
            var user = new User {Id = id, Login = content, Account = account};
            userRepository.Create(user);
            var holdAllUsers = userRepository.GetAll();
            var holdUser = holdAllUsers.Where(x => x.Login == content).FirstOrDefault();
            holdUser.Login = "UpdatedContent";
            userRepository.Update(holdUser);
            var holdUpdatedAccount = holdAllUsers.Where(x => x.Login == holdUser.Login).FirstOrDefault();
            Assert.NotEqual(user.Login, holdUpdatedAccount.Login);
            userRepository.Delete(holdUser.Id);
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestUpdateFailure(int id, string content)
        {
            var account = GetAccountHelper();
            var userRepository = SetUserRepository();
            var user = new User {Id = id, Login = content, Account = account};
            userRepository.Create(user);
            var holdAllUsers = userRepository.GetAll();
            var holdUser = holdAllUsers.Where(x => x.Login == content).FirstOrDefault();
            //holdUser.Login = "UpdatedContent";
            userRepository.Update(holdUser);
            var holdUpdatedAccount = holdAllUsers.Where(x => x.Login == holdUser.Login).FirstOrDefault();
            Assert.Equal(user.Login, holdUpdatedAccount.Login);
            userRepository.Delete(holdUser.Id);
            DeleteAccountHelper(account);
        }
    }
}