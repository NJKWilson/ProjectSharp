using System;

namespace ProjectSharp.Authorisation.Entities.User.Exceptions
{
    public class UserDependencyException : Exception
    {
        public UserDependencyException(Exception innerException)
            : base(message: "Service dependency error occurred, contact support.", innerException)
        {
        }
    }
}