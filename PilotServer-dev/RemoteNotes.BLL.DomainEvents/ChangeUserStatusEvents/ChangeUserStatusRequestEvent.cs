using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents
{
    public class ChangeUserStatusRequestEvent
    {
        public ChangeUserStatusRequestEvent(int userId, bool userStatus)
        {
            UserId = userId;
            UserStatus = userStatus;
        }

        public int UserId { get; set; }
        public bool UserStatus { get; set; }
    }
}
