using MySql.Data.MySqlClient;
using RemoteNotes.DAL.Contract;
using RemoteNotes.DAL.Contract.Provider;
using RemoteNotes.DAL.Contract.Repository;
using RemoteNotes.DAL.Repository;
using System;
using System.Collections.Generic;

namespace RemoteNotes.DAL
{
    public class RepositoryFactory : IRepositoryFactory
    {
        readonly Dictionary<Type, object> collection = new Dictionary<Type, object>();

        public RepositoryFactory(IDbProvider<MySqlConnection> dbProvider)
        {
            // Extension point of the factory
            this.collection.Add(typeof(IUserRepository), new UserRepository(dbProvider));
            this.collection.Add(typeof(INoteRepository), new NoteRepository(dbProvider));
            this.collection.Add(typeof(IAccountRepository), new AccountRepository(dbProvider));
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the collection");
            }

            return (T)this.collection[type];
        }
    }
}
