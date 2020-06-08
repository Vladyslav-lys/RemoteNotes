using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.EditAccountEvents;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Accounts
{
    public class EditAccountByRequest : IRequestActivity<EditAccountRequestEvent, EditAccountResponseEvent, IAccountRepository>
    {
        public EditAccountByRequest(IAccountRepository accountRepository)
        {
            Repository = accountRepository;
        }

        public IAccountRepository Repository { get; }


        public EditAccountResponseEvent Execute(EditAccountRequestEvent editAccountRequest)
        {
            editAccountRequest.Account.ModifyTime = DateTime.Now;
            try
            {
                Repository.Update(editAccountRequest.Account.ToEntity());
                var newAccount = Repository.GetById(editAccountRequest.Account.Id);
                return new EditAccountResponseEvent(newAccount);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Error updating account info...", ex);
            }
        }
    }
}