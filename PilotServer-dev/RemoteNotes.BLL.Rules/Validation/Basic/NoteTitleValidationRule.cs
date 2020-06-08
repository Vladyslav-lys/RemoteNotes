using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    public class NoteTitleValidationRule : ValidationRuleBase
    {
        public NoteTitleValidationRule() : base("Note title cannot be empty!")
        {
        }

        public ValidationResult IsValid(string title)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrEmpty(title))
            {
                var errorMessage = GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }

            return validationResult;
        }
    }
}