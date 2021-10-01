using System;
using System.Globalization;

namespace ProjectSharp.Shared.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base() {}

        public AuthenticationException(string message) : base(message) { }

        public AuthenticationException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}