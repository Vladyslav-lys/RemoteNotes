namespace RemoteNotes.BLL.Contract.UseCase
{
    public interface IUseCaseFactory
    {
        T Create<T>();
    }
}
