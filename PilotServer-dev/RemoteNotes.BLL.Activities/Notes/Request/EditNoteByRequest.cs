using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.EditNoteEvents;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.Activities.Notes.Request
{
    public class EditNoteByRequest : IRequestActivity<EditNoteRequestEvent, EditNoteResponseEvent, INoteRepository>
    {
        public EditNoteByRequest(INoteRepository noteRepository)
        {
            Repository = noteRepository;
        }

        public INoteRepository Repository { get; }

        public EditNoteResponseEvent Execute(EditNoteRequestEvent editNoteRequest)
        {
            editNoteRequest.NoteToEdit.ModifyTime = DateTime.Now;

            try
            {
                Repository.Update(editNoteRequest.NoteToEdit.ToEntity());
                var currentNote = Repository.GetById(editNoteRequest.NoteToEdit.Id);
                return new EditNoteResponseEvent(currentNote);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Error updating user info...", ex);
            }
        }
    }
}