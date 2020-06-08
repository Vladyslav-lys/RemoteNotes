using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.BLL.Rules.Helpers;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    public class LoginValidationRule : ValidationRuleBase
    {
        public LoginValidationRule() : base("Login must be a string composed of letters or digits.")
        {
        }

        public ValidationResult IsValid(string login)
        {
            var validationResult = new ValidationResult();

            if (login == null || !login.IsStringWithNumbers())
            {
                var errorMessage = GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }

            return validationResult;
        }
    }
}