using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.DomainEvents.EditNoteEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;

namespace RemoteNotes.BLL.Activities.Notes.Validation
{
    public class EditNoteValidationActivity : IValidationActivity<EditNoteRequestEvent>
    {
        private readonly IEditNoteOperationValidationRule editNoteOperationValidationRule;

        public EditNoteValidationActivity(IEditNoteOperationValidationRule editNoteOperationValidationRule)
        {
            this.editNoteOperationValidationRule = editNoteOperationValidationRule;
        }

        public void Validate(EditNoteRequestEvent request)
        {
            var validationResult =
                editNoteOperationValidationRule.IsValid(request.NoteToEdit.Title, request.NoteToEdit.Text, request.NoteToEdit.Image);

            if (!validationResult.IsValid)
                throw new SystemEditNoteValidationException(validationResult.GetErrorMessage());
        }
    }
}