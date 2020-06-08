using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    public class IsBannedValidationRule : ValidationRuleBase
    {
        public IsBannedValidationRule() : base("You are banned!")
        {
        }

        public ValidationResult IsValid(bool IsActive)
        {
            var validationResult = new ValidationResult();

            if (!IsActive)
            {
                var errorMessage = GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }

            return validationResult;
        }
    }
}
