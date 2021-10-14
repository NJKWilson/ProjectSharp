using System;

namespace ProjectSharp.Authorisation.Entities.User.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(Exception innerException)
            : base(message: "Invalid input, contact support.", innerException)
        {
        }
    }
}