using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Users.Exceptions
{
    public class UserServiceDependencyException : Exception
    {
        public UserServiceDependencyException(string message, Exception exception)
            : base(message, exception) { }
    }
}