using System.Collections.Generic;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.BLL.Rules.Validation.Basic;

namespace RemoteNotes.BLL.Rules.Validation.Operation
{
    public class EditNoteOperationValidationRule : IEditNoteOperationValidationRule
    {
        private readonly NoteTextValidationRule noteTextValidationRule;
        private readonly NoteImageValidationRule noteImageValidationRule;
        private readonly NoteTitleValidationRule noteTitleValidationRule;

        public EditNoteOperationValidationRule()
        {
            noteTitleValidationRule = new NoteTitleValidationRule();
            noteTextValidationRule = new NoteTextValidationRule();
            noteImageValidationRule = new NoteImageValidationRule();
        }

        public ValidationResult IsValid(string title, string text, byte[] imageBytes)
        {
            var validationResultCollection = new List<ValidationResult>
            {
                ValidateTitle(title),
                ValidateText(text),
                ValidateImage(imageBytes)
            };

            return new ValidationResult(validationResultCollection);
        }

        public ValidationResult ValidateTitle(string title)
        {
            return noteTitleValidationRule.IsValid(title);
        }

        public ValidationResult ValidateText(string text)
        {
            return noteTextValidationRule.IsValid(text);
        }

        public ValidationResult ValidateImage(byte[] image)
        {
            return noteImageValidationRule.IsValid(image);
        }
    }
}