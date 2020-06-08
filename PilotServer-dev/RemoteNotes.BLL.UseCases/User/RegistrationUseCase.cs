using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.CreateAccountEvents;
using RemoteNotes.BLL.DomainEvents.CreateUserEvents;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.UseCases.User
{
    public class RegistrationUseCase : IUseCase<CreateUserRequestEvent, CreateUserResponseEvent>
    {
        private readonly IRequestActivity<CreateAccountRequestEvent, CreateAccountResponseEvent, IAccountRepository> createAccountByRequest;
        private readonly IRequestActivity<CreateUserRequestEvent, CreateUserResponseEvent, IUserRepository> createUserByRequest;

        public RegistrationUseCase(
            IRequestActivity<CreateAccountRequestEvent, CreateAccountResponseEvent, IAccountRepository> accountByRequest,
            IRequestActivity<CreateUserRequestEvent, CreateUserResponseEvent, IUserRepository> userByRequest)
        {
            createAccountByRequest = accountByRequest;
            createUserByRequest = userByRequest;
        }

        public CreateUserResponseEvent Execute(CreateUserRequestEvent request)
        {
            try
            {
                var crateAccountResponseEvent = createAccountByRequest.Execute(new CreateAccountRequestEvent(request.User.Account));
                request.User.Account = crateAccountResponseEvent.AccountDTO;
                var crateUserResponseEvent = createUserByRequest.Execute(request);
                return crateUserResponseEvent;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
