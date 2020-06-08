using System;

namespace RemoteNotes.DAL.Core.Entity
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Account Account { get; set; }

        public DateTime PublishTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public byte[] Image { get; set; }

        public string Text { get; set; }
    }
}