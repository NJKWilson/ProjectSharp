using System;
using System.Globalization;

namespace ProjectSharp.Shared.Exceptions
{
    public class DbOperationFailedException : Exception
    {
        public DbOperationFailedException() : base() {}

        public DbOperationFailedException(string message) : base(message) { }

        public DbOperationFailedException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}