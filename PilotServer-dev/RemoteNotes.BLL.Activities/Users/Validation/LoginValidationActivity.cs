using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;

namespace RemoteNotes.BLL.Activities.Users.Validation
{
    public class LoginValidationActivity : IValidationActivity<EnterRequestEvent>
    {
        private readonly IEnterOperationValidationRule enterOperationValidation;

        public LoginValidationActivity(IEnterOperationValidationRule enterOperationValidationRule)
        {
            enterOperationValidation = enterOperationValidationRule;
        }

        public void Validate(EnterRequestEvent enterRequestEvent)
        {
            var validationResult =
                enterOperationValidation.IsValid(enterRequestEvent.Login, enterRequestEvent.Password);

            if (!validationResult.IsValid) throw new SystemEnterValidationException(validationResult.GetErrorMessage());
        }
    }
}