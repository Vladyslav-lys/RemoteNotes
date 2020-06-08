namespace RemoteNotes.DAL.Core.Entity
{
    public class User
    {
        public int Id { get; set; }

        public Account Account { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public short AccessLevel { get; set; } //smallint mysql
    }
}