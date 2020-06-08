using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Users.Request
{
    public class GetUserByRequest : IRequestActivity<EnterRequestEvent, EnterResponseEvent, IUserRepository>
    {
        public GetUserByRequest(IUserRepository userRepository)
        {
            Repository = userRepository;
        }

        public IUserRepository Repository { get; }

        public EnterResponseEvent Execute(EnterRequestEvent enterRequestEvent)
        {
            EnterResponseEvent response = null;

            try
            {
                var user = Repository.GetUserByLoginAndPassword(enterRequestEvent.Login, enterRequestEvent.Password);
                response = new EnterResponseEvent(user);
            }
            catch (Exception ex)
            {
                throw new MissingMemberException("Login or password is incorrect!", ex);
            }

            return response;
        }
    }
}