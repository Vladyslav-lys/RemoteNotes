using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.BLL.Rules.Validation.Basic;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;
using System.Collections.Generic;

namespace RemoteNotes.BLL.Rules.Validation.Operation
{
    public class AfterLoginOperationValidationRule : IAfterLoginOperationValidationRule
    {
        private readonly IsBannedValidationRule isBannedValidationRule;

        public AfterLoginOperationValidationRule()
        {
            isBannedValidationRule = new IsBannedValidationRule();
        }

        public ValidationResult IsValid(UserDTO user)
        {
            var validationResultCollection = new List<ValidationResult>
            {
                ValidateIsActive(user.IsActive),
            };

            return new ValidationResult(validationResultCollection);
        }

        public ValidationResult ValidateIsActive(bool IsActive)
        {
            return isBannedValidationRule.IsValid(IsActive);
        }
    }
}
