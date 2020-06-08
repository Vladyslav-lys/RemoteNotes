using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.EditAccountEvents;
using RemoteNotes.BLL.DomainEvents.EditNoteEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.DomainEvents.GetNotesEvents;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.BLL.UseCases.Note;
using RemoteNotes.BLL.UseCases.User;
using RemoteNotes.DAL.Contract.Repository;
using System;
using System.Collections.Generic;
using RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents;
using RemoteNotes.BLL.DomainEvents.CreateAccountEvents;
using RemoteNotes.BLL.DomainEvents.CreateUserEvents;
using RemoteNotes.BLL.DomainEvents.DeleteUserEvents;

namespace RemoteNotes.BLL.UseCases
{
    public class UseCaseFactory : IUseCaseFactory
    {
        readonly Dictionary<Type, object> collection = new Dictionary<Type, object>();

        public UseCaseFactory(IActivitiesFactory activitiesFactory)
        {
            // Extension point of the factory
            this.collection.Add(typeof(IUseCase<EnterRequestEvent, EnterResponseEvent>),
                new LoginUseCase(
                    activitiesFactory.Create<IValidationActivity<EnterRequestEvent>>(),
                    activitiesFactory.Create<IRequestActivity<EnterRequestEvent, EnterResponseEvent, IUserRepository>>(),
                    activitiesFactory.Create<IValidationActivity<EnterResponseEvent>>()
                ));

            this.collection.Add(typeof(IUseCase<EditUserRequestEvent, EditUserResponseEvent>),
                new EditUserUseCase(
                    activitiesFactory.Create<IValidationActivity<EditUserRequestEvent>>(),
                    activitiesFactory.Create<IRequestActivity<EditUserRequestEvent, EditUserResponseEvent, IUserRepository>>(),
                    activitiesFactory.Create<IRequestActivity<EditAccountRequestEvent, EditAccountResponseEvent, IAccountRepository>>(),
                    activitiesFactory.Create<IValidationActivity<AccessLevelCheckEvent>>()
                ));

            this.collection.Add(typeof(IUseCase<GetNotesRequestEvent, GetNotesResponseEvent>),
                new GetNotesUseCase(
                    activitiesFactory.Create<IRequestActivity<GetNotesRequestEvent, GetNotesResponseEvent, INoteRepository>>()
                ));

            this.collection.Add(typeof(IUseCase<EditNoteRequestEvent, EditNoteResponseEvent>),
                new EditNoteUseCase(
                    activitiesFactory.Create<IValidationActivity<EditNoteRequestEvent>>(),
                    activitiesFactory.Create<IRequestActivity<EditNoteRequestEvent, EditNoteResponseEvent, INoteRepository>>()
                ));

            this.collection.Add(typeof(IUseCase<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent>),
                new ChangeUserStatusUseCase(
                    activitiesFactory.Create<IRequestActivity<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent, IUserRepository>>()
                ));

            this.collection.Add(typeof(IUseCase<CreateUserRequestEvent, CreateUserResponseEvent>),
                new RegistrationUseCase(
                    activitiesFactory.Create < IRequestActivity < CreateAccountRequestEvent, CreateAccountResponseEvent, IAccountRepository >>(),
                    activitiesFactory.Create<IRequestActivity<CreateUserRequestEvent, CreateUserResponseEvent, IUserRepository>>()
                ));

            this.collection.Add(typeof(IUseCase<DeleteUserRequestEvent, DeleteUserResponseEvent>),
                new DeleteUserUseCase(
                    activitiesFactory.Create<IRequestActivity<DeleteUserRequestEvent, DeleteUserResponseEvent, IUserRepository>>()
                ));
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the collection");
            }

            return (T)this.collection[type];
        }
    }
}
