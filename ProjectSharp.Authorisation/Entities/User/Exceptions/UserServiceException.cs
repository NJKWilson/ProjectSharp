using System;

namespace ProjectSharp.Authorisation.Entities.User.Exceptions
{
    public class UserServiceException : Exception
    {
        public UserServiceException(Exception innerException)
            : base(message: "Service error occurred, contact support.", innerException)
        {
        }
    }
}