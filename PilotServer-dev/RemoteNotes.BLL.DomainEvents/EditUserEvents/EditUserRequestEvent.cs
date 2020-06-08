using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditUserEvents
{
    public class EditUserRequestEvent
    {
        public EditUserRequestEvent(UserDTO user)
        {
            User = user;
        }

        public UserDTO User { get; set; }
    }
}