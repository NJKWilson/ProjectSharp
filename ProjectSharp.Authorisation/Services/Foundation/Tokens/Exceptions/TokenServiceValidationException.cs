using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Tokens.Exceptions
{
    public class TokenServiceValidationException : Exception
    {
        public TokenServiceValidationException(string message)
            : base(message: message) { }
    }
}