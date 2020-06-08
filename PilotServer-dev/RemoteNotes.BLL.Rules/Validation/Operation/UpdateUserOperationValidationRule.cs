using System;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.BLL.Rules.Validation.Basic;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.Rules.Validation.Operation
{
    public class UpdateUserOperationValidationRule : IUpdateUserOperationValidationRule
    {
        private readonly EmailValidationRule emailValidationRule;

        public UpdateUserOperationValidationRule()
        {
            emailValidationRule = new EmailValidationRule();
        }

        public ValidationResult IsValid(UserDTO user)
        {
            if (user != null)
                return ValidateEmail(user.Account.Email);
            throw new NullReferenceException("User is null. Nothing to validate");
        }

        public ValidationResult ValidateEmail(string email)
        {
            return emailValidationRule.IsValid(email);
        }
    }
}