using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditAccountEvents
{
    public class EditAccountRequestEvent
    {
        public EditAccountRequestEvent(AccountDTO account)
        {
            Account = account;
        }

        public AccountDTO Account { get; set; }
    }
}