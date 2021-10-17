using System;

namespace ProjectSharp.Authorisation.Services.Orchestration.UserManagement.Exceptions
{
    public class UserManagementServiceValidationException : Exception
    {
        public UserManagementServiceValidationException(string message)
            : base(message) {}
    }
}