using System;

namespace RemoteNotes.DAL.Core.Entity
{
    public class Account
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public byte[] Photo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }
    }
}