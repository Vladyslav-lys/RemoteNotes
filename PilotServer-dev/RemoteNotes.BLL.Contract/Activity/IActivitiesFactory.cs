namespace RemoteNotes.BLL.Contract.Activity
{
    public interface IActivitiesFactory
    {
        T Create<T>();
    }
}
