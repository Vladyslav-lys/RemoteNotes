using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditUserEvents
{
    public class EditUserResponseEvent
    {
        public EditUserResponseEvent(User user)
        {
            UserDTO = user.ToDTO();
        }

        public UserDTO UserDTO { get; set; }
    }
}