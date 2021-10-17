using System;

namespace ProjectSharp.Authorisation.Models.Token.Exceptions
{
    public class TokenServiceValidationException : Exception
    {
        public TokenServiceValidationException(string message)
            : base(message: message) { }
    }
}