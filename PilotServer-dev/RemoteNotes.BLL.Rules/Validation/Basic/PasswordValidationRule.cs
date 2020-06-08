using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.BLL.Rules.Helpers;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    public class PasswordValidationRule : ValidationRuleBase
    {
        public PasswordValidationRule() : base("Password must be a string composed of: letters, digits, _")
        {
        }

        public ValidationResult IsValid(string password)
        {
            var validationResult = new ValidationResult();

            if (password == null || !password.IsStringWithNumbersAndUnderscores())
            {
                var errorMessage = GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }

            return validationResult;
        }
    }
}