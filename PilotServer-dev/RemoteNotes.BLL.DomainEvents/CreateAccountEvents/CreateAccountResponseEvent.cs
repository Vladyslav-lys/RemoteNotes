using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.CreateAccountEvents
{
    public class CreateAccountResponseEvent
    {
        public CreateAccountResponseEvent(Account account)
        {
            AccountDTO = account.ToDTO();
        }

        public AccountDTO AccountDTO { get; set; }
    }
}
