using RemoteNotes.BLL.Contract.Rule.Base;

namespace RemoteNotes.BLL.Contract.Rule
{
    public interface IEditNoteOperationValidationRule
    {
        ValidationResult IsValid(string title, string text, byte[] imageBytes);
        ValidationResult ValidateTitle(string title);
        ValidationResult ValidateText(string text);
        ValidationResult ValidateImage(byte[] imageBytes);
    }
}