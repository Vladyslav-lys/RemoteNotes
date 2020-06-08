using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.EditNoteEvents
{
    public class EditNoteResponseEvent
    {
        public EditNoteResponseEvent(Note note)
        {
            NoteDTO = note.ToDTO();
        }

        public NoteDTO NoteDTO { get; set; }
    }
}