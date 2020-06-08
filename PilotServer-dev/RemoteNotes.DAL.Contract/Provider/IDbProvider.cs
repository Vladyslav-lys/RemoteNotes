using System.Data.Common;

namespace RemoteNotes.DAL.Contract.Provider
{
    public interface IDbProvider<T> where T : DbConnection
    {
        T Connection { get; }
    }
}