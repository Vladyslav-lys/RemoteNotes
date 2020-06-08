namespace RemoteNotes.BLL.Contract.Activity
{
    public interface IRequestActivity<RequestEvent, ResponseEvent, Repo>
    {
        Repo Repository { get; }
        ResponseEvent Execute(RequestEvent request);
    }
}