using RemoteNotes.BLL.Activities.Accounts;
using RemoteNotes.BLL.Activities.Notes.Request;
using RemoteNotes.BLL.Activities.Notes.Validation;
using RemoteNotes.BLL.Activities.Users.Request;
using RemoteNotes.BLL.Activities.Users.Validation;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.DomainEvents.EditAccountEvents;
using RemoteNotes.BLL.DomainEvents.EditNoteEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.DomainEvents.GetNotesEvents;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.DAL.Contract;
using RemoteNotes.DAL.Contract.Repository;
using System;
using System.Collections.Generic;
using RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents;
using RemoteNotes.BLL.DomainEvents.CreateAccountEvents;
using RemoteNotes.BLL.DomainEvents.CreateUserEvents;
using RemoteNotes.BLL.DomainEvents.DeleteUserEvents;

namespace RemoteNotes.BLL.Activities
{
    public class ActivitiesFactory : IActivitiesFactory
    {
        readonly Dictionary<Type, object> ruleCollection = new Dictionary<Type, object>();

        public ActivitiesFactory(IRepositoryFactory repositoryFactory, IValidationRuleFactory validationRuleFactory)
        {
            // Extension point of the factory
            this.ruleCollection.Add(
                typeof(IValidationActivity<EnterRequestEvent>), 
                new LoginValidationActivity(validationRuleFactory.Create<IEnterOperationValidationRule>())
                );
            this.ruleCollection.Add(
                typeof(IRequestActivity<EnterRequestEvent, EnterResponseEvent, IUserRepository>), 
                new GetUserByRequest(repositoryFactory.Create<IUserRepository>())
                );

            this.ruleCollection.Add(
                typeof(IValidationActivity<EditUserRequestEvent>), 
                new EditUserValidationActivity(validationRuleFactory.Create<IUpdateUserOperationValidationRule>())
                );
            this.ruleCollection.Add(
                typeof(IRequestActivity<EditUserRequestEvent, EditUserResponseEvent, IUserRepository>), 
                new EditUserByRequest(repositoryFactory.Create<IUserRepository>())
                );

            this.ruleCollection.Add(
                typeof(IRequestActivity<EditAccountRequestEvent, EditAccountResponseEvent, IAccountRepository>), 
                new EditAccountByRequest(repositoryFactory.Create<IAccountRepository>())
                );

            this.ruleCollection.Add(
                typeof(IRequestActivity<GetNotesRequestEvent, GetNotesResponseEvent, INoteRepository>), 
                new GetNotesByAccountId(repositoryFactory.Create<INoteRepository>())
                );

            this.ruleCollection.Add(
                typeof(IValidationActivity<EditNoteRequestEvent>), 
                new EditNoteValidationActivity(validationRuleFactory.Create<IEditNoteOperationValidationRule>())
                );
            this.ruleCollection.Add(
                typeof(IRequestActivity<EditNoteRequestEvent, EditNoteResponseEvent, INoteRepository>), 
                new EditNoteByRequest(repositoryFactory.Create<INoteRepository>())
                );

            this.ruleCollection.Add(
                typeof(IValidationActivity<AccessLevelCheckEvent>), 
                new AccessLevelValidationActivity()
                );
            this.ruleCollection.Add(
                typeof(IValidationActivity<EnterResponseEvent>), 
                new AfterLoginValidationActivity(validationRuleFactory.Create<IAfterLoginOperationValidationRule>())
                );

            this.ruleCollection.Add(
                typeof(IRequestActivity<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent, IUserRepository>),
                new ChangeUserStatusByRequest(repositoryFactory.Create<IUserRepository>())
            );

            this.ruleCollection.Add(
                typeof(IRequestActivity<CreateUserRequestEvent, CreateUserResponseEvent, IUserRepository>),
                new CreateUserByRequest(repositoryFactory.Create<IUserRepository>())
            );

            this.ruleCollection.Add(
                typeof(IRequestActivity<CreateAccountRequestEvent, CreateAccountResponseEvent, IAccountRepository>),
                new CreateAccountByRequest(repositoryFactory.Create<IAccountRepository>())
            );

            this.ruleCollection.Add(
                typeof(IRequestActivity<DeleteUserRequestEvent, DeleteUserResponseEvent, IUserRepository>),
                new DeleteUserByRequest(repositoryFactory.Create<IUserRepository>())
            );
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.ruleCollection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the rule collection");
            }

            return (T)this.ruleCollection[type];
        }
    }
}
