using RemoteNotes.DAL.Core.Entity.Enums;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditUserEvents
{
    public class AccessLevelCheckEvent
    {
        public AccessLevelCheckEvent(UserDTO user, AccessLevel minAccessLevel)
        {
            User = user;
            MinAccessLevel = minAccessLevel;
        }

        public UserDTO User { get; set; }

        public AccessLevel MinAccessLevel { get; set; }
    }
}
