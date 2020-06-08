using RemoteNotes.DAL.Core.Entity;

namespace RemoteNotes.DAL.Contract.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccountLastId();
    }
}