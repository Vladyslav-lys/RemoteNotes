using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.DeleteUserEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Users.Request
{
    public class DeleteUserByRequest : IRequestActivity<DeleteUserRequestEvent, DeleteUserResponseEvent, IUserRepository>
    {
        public DeleteUserByRequest(IUserRepository userRepository)
        {
            Repository = userRepository;
        }

        public IUserRepository Repository { get; }

        public DeleteUserResponseEvent Execute(DeleteUserRequestEvent request)
        {
            try
            {
                Repository.CascadeDeleteUser(request.UserId);
                return new DeleteUserResponseEvent();
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Unable to delete account...", ex);
            }
        }
    }
}
