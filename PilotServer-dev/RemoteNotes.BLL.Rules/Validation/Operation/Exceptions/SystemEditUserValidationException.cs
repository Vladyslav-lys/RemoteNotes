using System;

namespace RemoteNotes.BLL.Rules.Validation.Operation.Exceptions
{
    public class SystemEditUserValidationException : Exception
    {
        public SystemEditUserValidationException()
        {
        }

        public SystemEditUserValidationException(string message) : base(message)
        {
        }

        public SystemEditUserValidationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}