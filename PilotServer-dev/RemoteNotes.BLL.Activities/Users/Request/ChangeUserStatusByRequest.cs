using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Users.Request
{
    class ChangeUserStatusByRequest : IRequestActivity<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent, IUserRepository>
    {
        public ChangeUserStatusByRequest(IUserRepository userRepository)
        {
            Repository = userRepository;
        }

        public IUserRepository Repository { get; }


        public ChangeUserStatusResponseEvent Execute(ChangeUserStatusRequestEvent activateUserRequest)
        {
            try
            {
                Repository.ChangeUserStatusById(activateUserRequest.UserId, activateUserRequest.UserStatus);
                var newUser = Repository.GetById(activateUserRequest.UserId);
                return new ChangeUserStatusResponseEvent(newUser);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Unable to change user status...", ex);
            }
        }
    }
}
