using System.Collections.Generic;
using AutoMapper;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.GetNotesEvents
{
    public class GetNotesResponseEvent
    {
        public List<NoteDTO> NotesDTO = new List<NoteDTO>();

        public GetNotesResponseEvent(List<Note> notes)
        {
            NotesDTO = notes.ToDTO();
        }
    }
}