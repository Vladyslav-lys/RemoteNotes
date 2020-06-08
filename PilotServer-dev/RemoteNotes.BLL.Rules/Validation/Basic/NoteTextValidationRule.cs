using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    public class NoteTextValidationRule : ValidationRuleBase
    {
        public NoteTextValidationRule() : base("Note text cannot be empty!")
        {
        }

        public ValidationResult IsValid(string text)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrEmpty(text))
            {
                var errorMessage = GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }

            return validationResult;
        }
    }
}