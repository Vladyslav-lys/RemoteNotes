using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.CreateAccountEvents
{
    public class CreateAccountRequestEvent
    {
        public CreateAccountRequestEvent(AccountDTO account)
        {
            Account = account;
        }

        public AccountDTO Account { get; set; }
    }
}
