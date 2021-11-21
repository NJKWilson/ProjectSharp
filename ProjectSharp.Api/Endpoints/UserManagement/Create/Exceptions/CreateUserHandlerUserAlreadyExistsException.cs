using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;

public class CreateUserHandlerUserAlreadyExistsException : Exception
{
    public CreateUserHandlerUserAlreadyExistsException(User user)
        : base($"Email address '{user.Email}' already registered.") { }
}