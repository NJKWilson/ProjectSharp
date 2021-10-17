using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Passwords.Exceptions
{
    public class PasswordServiceDependencyException : Exception
    {
        public PasswordServiceDependencyException(string message, Exception exception) 
            : base(message, exception) { }
    }
}