using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Users.Exceptions
{
    public class UserServiceValidationException : Exception
    {
        public UserServiceValidationException(string message)
            : base(message: message) { }
    }
}