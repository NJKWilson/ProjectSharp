using System;
using System.Globalization;

namespace ProjectSharp.WebApi.Common.Exceptions
{
    public class ApplicationUserCredentialsException : Exception
    {
        public ApplicationUserCredentialsException() : base() {}

        public ApplicationUserCredentialsException(string message) : base(message) { }

        public ApplicationUserCredentialsException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}