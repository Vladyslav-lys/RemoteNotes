using System.Collections.Generic;
using RemoteNotes.DAL.Core.Entity;

namespace RemoteNotes.DAL.Contract.Repository
{
    public interface INoteRepository : IRepository<Note>
    {
        List<Note> GetNotesByAccountId(int accountId);
    }
}