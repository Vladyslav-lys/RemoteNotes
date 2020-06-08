using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.CreateAccountEvents;
using RemoteNotes.BLL.DomainEvents.CreateUserEvents;
using RemoteNotes.BLL.DomainEvents.EditAccountEvents;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Accounts
{
    public class CreateAccountByRequest : IRequestActivity<CreateAccountRequestEvent, CreateAccountResponseEvent, IAccountRepository>
    {
        public CreateAccountByRequest(IAccountRepository accountRepository)
        {
            Repository = accountRepository;
        }

        public IAccountRepository Repository { get; }

        public CreateAccountResponseEvent Execute(CreateAccountRequestEvent request)
        {
            try
            {
                Repository.Create(request.Account.ToEntity());
                var newAccount = Repository.GetAccountLastId();
                return new CreateAccountResponseEvent(newAccount);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Unable to create account...", ex);
            }
        }
    }
}
