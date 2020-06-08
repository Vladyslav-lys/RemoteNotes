using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditNoteEvents
{
    public class EditNoteRequestEvent
    {
        public EditNoteRequestEvent(NoteDTO note)
        {
            NoteToEdit = note;
        }

        public NoteDTO NoteToEdit { get; set; }
    }
}