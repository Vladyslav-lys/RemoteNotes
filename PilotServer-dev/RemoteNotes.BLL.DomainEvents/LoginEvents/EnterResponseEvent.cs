using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.LoginEvents
{
    public sealed class EnterResponseEvent
    {
        public EnterResponseEvent(User user)
        {
            this.UserDTO = user.ToDTO();
        }

        public UserDTO UserDTO { get; set; }
    }
}