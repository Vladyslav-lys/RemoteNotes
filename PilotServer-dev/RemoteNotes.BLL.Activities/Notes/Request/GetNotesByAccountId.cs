using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.GetNotesEvents;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Notes.Request
{
    public class GetNotesByAccountId : IRequestActivity<GetNotesRequestEvent, GetNotesResponseEvent, INoteRepository>
    {
        public GetNotesByAccountId(INoteRepository noteRepository)
        {
            Repository = noteRepository;
        }

        public INoteRepository Repository { get; }

        public GetNotesResponseEvent Execute(GetNotesRequestEvent enterRequestEvent)
        {
            GetNotesResponseEvent response = null;

            try
            {
                var notes = Repository.GetNotesByAccountId(enterRequestEvent.AccountId);
                if (notes.Count == 0) throw new ArgumentException("Incorrect accountId");
                response = new GetNotesResponseEvent(notes);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("No notes tied to this account", ex);
            }
            catch (Exception ex)
            {
                throw new MissingMemberException("Notes not found!", ex);
            }

            return response;
        }
    }
}