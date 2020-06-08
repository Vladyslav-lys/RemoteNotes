using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.CreateUserEvents
{
    public class CreateUserRequestEvent
    {
        public CreateUserRequestEvent(UserDTO user)
        {
            User = user;
        }

        public UserDTO User { get; set; }
    }
}
