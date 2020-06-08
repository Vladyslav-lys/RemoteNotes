using System;
using System.Linq;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.DAL.Repository;
using Xunit;

namespace RemoteNotes.DAL.Tests
{
    public class NoteRepositiryTests
    {
        private Account account;
        public MySqlProvider service;

        public AccountRepository SetAccountRepository()
        {
            service = new MySqlProvider(
                "server=localhost;UserId=root;Password=1234;database=remotenotesIntegrationTest;allow zero datetime=yes;Allow User Variables = True");
            var hold = new AccountRepository(service);
            return hold;
        }

        public NoteRepository SetNoteRepository()
        {
            service = new MySqlProvider(
                "server=localhost;UserId=root;Password=1234;database=remotenotesIntegrationTest;allow zero datetime=yes;Allow User Variables = True");
            var hold = new NoteRepository(service);
            return hold;
        }

        public Account GetAccountHelper()
        {
            var accountRepository = SetAccountRepository();
            var account = new Account {Id = 0, FirstName = "testAccount"};
            var holdAllAccounts = accountRepository?.GetAll();
            var holdAccount = holdAllAccounts.Where(x => x.FirstName == "testAccount").FirstOrDefault();
            if (holdAccount == null || holdAllAccounts == null)
            {
                accountRepository.Create(account);
                holdAllAccounts = accountRepository.GetAll();
                holdAccount = holdAllAccounts.Where(x => x.FirstName == "testAccount").FirstOrDefault();
            }


            return holdAccount;
        }

        public void DeleteAccountHelper(Account account)
        {
            //AccountRepository accountRepository = SetAccountRepository();
            //var holdAllAccounts = accountRepository.GetAll();
            //var holdAccount = holdAllAccounts.Where(x => x.FirstName == "testAccount").FirstOrDefault();
            // accountRepository.Delete(holdAccount.Id);
        }

        [Theory]
        [InlineData(0, "testContent1")]
        [InlineData(1, "testContent2")]
        [InlineData(2, "testContent3")]
        public void TestCreate(int id, string content)
        {
            var account = GetAccountHelper();
            var noteRepository = SetNoteRepository();
            var note = new Note {Id = id, Text = content, Account = account};
            noteRepository.Create(note);
            var holdAllNotes = noteRepository?.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Text == content).FirstOrDefault();
            Assert.Equal(note.Text, holdNote.Text);
            noteRepository.Delete(holdNote.Id);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestCreateFailure(int id, string content)
        {
            var account = GetAccountHelper();
            var noteRepository = SetNoteRepository();
            var note = new Note {Id = id, Text = content, Account = account};
            noteRepository.Create(note);
            var holdAllNotes = noteRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Text == content).FirstOrDefault();
            Assert.NotEqual(note.Text, "not correct content");
            noteRepository.Delete(holdNote.Id);
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestDelete(int id, string content)
        {
            var account = GetAccountHelper();
            var noteRepository = SetNoteRepository();
            var note = new Note {Id = id, Text = content, Account = account};
            noteRepository.Create(note);

            var holdAllNotes = noteRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Text == content).FirstOrDefault();
            noteRepository.Delete(holdNote.Id);
            Assert.Null(noteRepository.GetById(holdNote.Id));
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestDeleteFailure(int id, string content)
        {
            var account = GetAccountHelper();
            var noteRepository = SetNoteRepository();
            var note = new Note {Id = id, Text = content, Account = account};
            noteRepository.Create(note);

            var holdAllNotes = noteRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Text == content).FirstOrDefault();
            noteRepository.Delete(-1);
            Assert.NotNull(noteRepository.GetById(holdNote.Id));
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestUpdate(int id, string content)
        {
            var account = GetAccountHelper();
            var noteRepository = SetNoteRepository();
            var note = new Note {Id = id, Text = content, Account = account, ModifyTime = new DateTime(1000, 2, 11)};
            noteRepository.Create(note);
            var holdAllNotes = noteRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Text == content).FirstOrDefault();
            holdNote.Text = "UpdatedContent";
            holdNote.ModifyTime = DateTime.Now;
            noteRepository.Update(holdNote);
            var holdUpdatedAccount = holdAllNotes.Where(x => x.Text == holdNote.Text).FirstOrDefault();
            Assert.NotEqual(note.Text, holdUpdatedAccount.Text);
            noteRepository.Delete(holdNote.Id);
            DeleteAccountHelper(account);
        }

        [Theory]
        [InlineData(0, "testName1")]
        [InlineData(1, "testName2")]
        [InlineData(2, "testName3")]
        public void TestUpdateFailure(int id, string content)
        {
            var account = GetAccountHelper();
            var noteRepository = SetNoteRepository();
            var note = new Note {Id = id, Text = content, Account = account};
            noteRepository.Create(note);
            var holdAllNotes = noteRepository.GetAll();
            var holdNote = holdAllNotes.Where(x => x.Text == content).FirstOrDefault();
            // holdNote.Text = "UpdatedContent";
            noteRepository.Update(holdNote);
            var holdUpdatedAccount = holdAllNotes.Where(x => x.Text == holdNote.Text).FirstOrDefault();
            Assert.Equal(note.Text, holdUpdatedAccount.Text);
            noteRepository.Delete(holdNote.Id);
            DeleteAccountHelper(account);
        }
    }
}