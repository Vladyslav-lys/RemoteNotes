using System;

namespace RemoteNotes.BLL.Rules.Validation.Operation.Exceptions
{
    public class SystemEnterValidationException : Exception
    {
        public SystemEnterValidationException()
        {
        }

        public SystemEnterValidationException(string message) : base(message)
        {
        }

        public SystemEnterValidationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}