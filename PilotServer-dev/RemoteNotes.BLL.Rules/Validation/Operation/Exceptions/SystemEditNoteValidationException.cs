using System;

namespace RemoteNotes.BLL.Rules.Validation.Operation.Exceptions
{
    public class SystemEditNoteValidationException : Exception
    {
        public SystemEditNoteValidationException()
        {
        }

        public SystemEditNoteValidationException(string message) : base(message)
        {
        }

        public SystemEditNoteValidationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}