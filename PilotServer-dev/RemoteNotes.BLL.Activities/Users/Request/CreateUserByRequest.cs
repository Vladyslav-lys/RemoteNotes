using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents;
using RemoteNotes.BLL.DomainEvents.CreateUserEvents;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Users.Request
{
    public class CreateUserByRequest : IRequestActivity<CreateUserRequestEvent, CreateUserResponseEvent, IUserRepository>
    {
        public CreateUserByRequest(IUserRepository userRepository)
        {
            Repository = userRepository;
        }

        public IUserRepository Repository { get; }

        public CreateUserResponseEvent Execute(CreateUserRequestEvent request)
        {
            try
            {
                Repository.Create(request.User.ToEntity());
                var newUser = Repository.GetLastUserId();
                return new CreateUserResponseEvent(newUser);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Impossible to create user...", ex);
            }
        }
    }
}
