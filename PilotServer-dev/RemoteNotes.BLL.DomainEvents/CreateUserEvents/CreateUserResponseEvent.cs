using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.CreateUserEvents
{
    public class CreateUserResponseEvent
    {
        public CreateUserResponseEvent(User user)
        {
            UserDTO = user.ToDTO();
        }

        public UserDTO UserDTO { get; set; }
    }
}
