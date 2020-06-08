using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.BLL.DomainEvents.DeleteUserEvents
{
    public class DeleteUserRequestEvent
    {
        public int UserId { get; set; }

        public DeleteUserRequestEvent(int userId)
        {
            UserId = userId;
        }
    }
}
