using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents
{
    public class ChangeUserStatusResponseEvent
    {
        public ChangeUserStatusResponseEvent(User user)
        {
            UserDTO = user.ToDTO();
        }
        public UserDTO UserDTO { get; set; }
    }
}
