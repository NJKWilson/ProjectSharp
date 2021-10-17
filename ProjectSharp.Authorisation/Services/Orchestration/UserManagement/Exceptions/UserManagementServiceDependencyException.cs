using System;

namespace ProjectSharp.Authorisation.Services.Orchestration.UserManagement.Exceptions
{
    public class UserManagementServiceDependencyException : Exception
    {
        public UserManagementServiceDependencyException(string message, Exception exception)
        : base(message, exception) { }
    }
}