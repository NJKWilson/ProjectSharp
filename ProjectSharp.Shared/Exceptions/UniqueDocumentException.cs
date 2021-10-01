using System;
using System.Globalization;

namespace ProjectSharp.Shared.Exceptions
{
    public class UniqueDocumentException : Exception
    {
        public UniqueDocumentException() : base() {}

        public UniqueDocumentException(string message) : base(message) { }

        public UniqueDocumentException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}