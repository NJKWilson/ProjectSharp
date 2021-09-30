using System;
using System.Globalization;

namespace ProjectSharp.WebApi.Common.Exceptions
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException() : base() {}

        public RequestValidationException(string message) : base(message) { }

        public RequestValidationException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}