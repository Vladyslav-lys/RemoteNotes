namespace RemoteNotes.BLL.DomainEvents.GetNotesEvents
{
    public class GetNotesRequestEvent
    {
        public int AccountId;

        public GetNotesRequestEvent(int accountId)
        {
            AccountId = accountId;
        }
    }
}