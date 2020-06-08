namespace RemoteNotes.BLL.DomainEvents.LoginEvents
{
    public sealed class EnterRequestEvent
    {
        public EnterRequestEvent(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}