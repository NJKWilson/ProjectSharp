using System;

namespace ProjectSharp.Authorisation.Models.Token.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(Exception exception)
            : base(message: $"Jwt token is invalid.", exception) { }
    }
}