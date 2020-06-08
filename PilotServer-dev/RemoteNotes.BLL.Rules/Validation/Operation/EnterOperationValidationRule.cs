using System.Collections.Generic;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.BLL.Rules.Validation.Basic;

namespace RemoteNotes.BLL.Rules.Validation.Operation
{
    public class EnterOperationValidationRule : IEnterOperationValidationRule
    {
        private readonly LoginValidationRule loginValidationRule;
        private readonly PasswordValidationRule passwordValidationRule;

        public EnterOperationValidationRule()
        {
            passwordValidationRule = new PasswordValidationRule();
            loginValidationRule = new LoginValidationRule();
        }

        public ValidationResult IsValid(string login, string password)
        {
            var validationResultCollection = new List<ValidationResult>
            {
                ValidateLogin(login),
                ValidatePassword(password)
            };

            return new ValidationResult(validationResultCollection);
        }

        public ValidationResult ValidateLogin(string login)
        {
            return loginValidationRule.IsValid(login);
        }

        public ValidationResult ValidatePassword(string password)
        {
            return passwordValidationRule.IsValid(password);
        }
    }
}