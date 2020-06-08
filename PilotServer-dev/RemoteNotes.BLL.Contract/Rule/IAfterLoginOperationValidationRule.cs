using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.Contract.Rule
{
    public interface IAfterLoginOperationValidationRule
    {
        ValidationResult IsValid(UserDTO user);
        ValidationResult ValidateIsActive(bool IsActive);
    }
}
