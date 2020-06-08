using RemoteNotes.BLL.Contract.Rule.Base;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.Contract.Rule
{
    public interface IUpdateUserOperationValidationRule
    {
        ValidationResult IsValid(UserDTO user);

        ValidationResult ValidateEmail(string email);
    }
}