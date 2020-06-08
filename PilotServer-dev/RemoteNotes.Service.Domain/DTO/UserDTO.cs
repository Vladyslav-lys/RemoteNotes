namespace RemoteNotes.Service.Domain.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public AccountDTO Account { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public short AccessLevel { get; set; } //smallint mysql
    }
}
