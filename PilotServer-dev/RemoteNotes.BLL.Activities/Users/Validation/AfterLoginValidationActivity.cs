using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.Activities.Users.Validation
{
    public class AfterLoginValidationActivity : IValidationActivity<EnterResponseEvent>
    {
        private readonly IAfterLoginOperationValidationRule afterLoginValidation;

        public AfterLoginValidationActivity(IAfterLoginOperationValidationRule afterLoginValidation)
        {
            this.afterLoginValidation = afterLoginValidation;
        }
        public void Validate(EnterResponseEvent response)
        {
            var validationResult = afterLoginValidation.IsValid(response.UserDTO);

            if (!validationResult.IsValid)
                throw new SystemEnterValidationException(validationResult.GetErrorMessage());
        }
    }
}
