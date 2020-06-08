using RemoteNotes.DAL.Core.Entity;

namespace RemoteNotes.DAL.Contract.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLoginAndPassword(string login, string password);

        User GetUserByLogin(string login);

        void ChangeUserStatusById(int id, bool status);

        User GetLastUserId();

        void CascadeDeleteUser(int id);

    }
}