using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Passwords.Exceptions
{
    public class PasswordServiceValidationException : Exception
    {
        public PasswordServiceValidationException(string message)
            : base(message) {}
    }
}