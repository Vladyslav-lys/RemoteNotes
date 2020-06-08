using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using System.Data;

namespace RemoteNotes.BLL.Activities.Users.Validation
{
    public class AccessLevelValidationActivity : IValidationActivity<AccessLevelCheckEvent>
    {
        public void Validate(AccessLevelCheckEvent request)
        {
            if (request.User.AccessLevel < (short)request.MinAccessLevel)
                throw new DataException("Your access level is too smal for this");
        }
    }
}
