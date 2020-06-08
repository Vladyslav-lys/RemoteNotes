using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;

namespace RemoteNotes.BLL.Activities.Users.Validation
{
    public class EditUserValidationActivity : IValidationActivity<EditUserRequestEvent>
    {
        private readonly IUpdateUserOperationValidationRule updateUserValidation;

        public EditUserValidationActivity(IUpdateUserOperationValidationRule updateUserValidation)
        {
            this.updateUserValidation = updateUserValidation;
        }

        public void Validate(EditUserRequestEvent enterRequest)
        {
            var validationResult = updateUserValidation.IsValid(enterRequest.User);

            if (!validationResult.IsValid)
                throw new SystemEditUserValidationException(validationResult.GetErrorMessage());
        }
    }
}