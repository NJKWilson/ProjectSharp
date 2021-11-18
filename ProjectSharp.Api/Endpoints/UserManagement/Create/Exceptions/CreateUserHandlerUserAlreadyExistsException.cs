namespace ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;

public class CreateUserHandlerUserAlreadyExistsException : Exception
{
    public CreateUserHandlerUserAlreadyExistsException(string message)
        : base(message) { }
}