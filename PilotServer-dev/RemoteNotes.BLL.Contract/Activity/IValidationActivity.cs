namespace RemoteNotes.BLL.Contract.Activity
{
    public interface IValidationActivity<T>
    {
        void Validate(T request);
    }
}