using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Users.Request
{
    public class EditUserByRequest : IRequestActivity<EditUserRequestEvent, EditUserResponseEvent, IUserRepository>
    {
        public EditUserByRequest(IUserRepository userRepository)
        {
            Repository = userRepository;
        }

        public IUserRepository Repository { get; }

        public EditUserResponseEvent Execute(EditUserRequestEvent editUserRequest)
        {
            try
            {
                Repository.Update(editUserRequest.User.ToEntity());
                var newUser = Repository.GetById(editUserRequest.User.Id);
                return new EditUserResponseEvent(newUser);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Error updating user info...", ex);
            }
        }
    }
}