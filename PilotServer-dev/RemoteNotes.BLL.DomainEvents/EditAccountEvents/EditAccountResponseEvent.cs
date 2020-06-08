using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditAccountEvents
{
    public class EditAccountResponseEvent
    {
        public EditAccountResponseEvent(Account account)
        {
            AccountDTO = account.ToDTO();
        }

        public AccountDTO AccountDTO { get; set; }
    }
}