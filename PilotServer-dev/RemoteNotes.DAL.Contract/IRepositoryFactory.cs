namespace RemoteNotes.DAL.Contract
{
    public interface IRepositoryFactory
    {
        T Create<T>();
    }
}
