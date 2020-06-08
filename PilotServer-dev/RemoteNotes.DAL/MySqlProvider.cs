using MySql.Data.MySqlClient;
using RemoteNotes.DAL.Contract.Provider;

namespace RemoteNotes.DAL
{
    public class MySqlProvider : IDbProvider<MySqlConnection>
    {
        public MySqlProvider(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connection { get; }
    }
}