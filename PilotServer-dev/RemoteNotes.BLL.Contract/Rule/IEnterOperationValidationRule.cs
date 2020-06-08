using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Contract.Rule
{
    public interface IEnterOperationValidationRule
    {
        ValidationResult IsValid(string login, string password);

        ValidationResult ValidateLogin(string login);

        ValidationResult ValidatePassword(string password);
    }
}