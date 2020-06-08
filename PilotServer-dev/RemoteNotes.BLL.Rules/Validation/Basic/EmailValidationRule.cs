using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Rules.Validation.Basic
{
    internal class EmailValidationRule : ValidationRuleBase
    {
        public EmailValidationRule() : base("Your email is not valid! Only @ffeks.dp.ua enabled")
        {
        }

        public ValidationResult IsValid(string email)
        {
            var validationResult = new ValidationResult();

            if (email == null || !email.EndsWith("@ffeks.dp.ua"))
            {
                var errorMessage = GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }

            return validationResult;
        }
    }
}