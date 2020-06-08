namespace RemoteNotes.BLL.Contract.UseCase
{
    public interface IUseCase<in TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }
}