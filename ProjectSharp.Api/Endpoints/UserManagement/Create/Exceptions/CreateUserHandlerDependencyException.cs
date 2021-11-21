namespace ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;

public class CreateUserHandlerDependencyException : Exception
{
    public CreateUserHandlerDependencyException(string message, Exception exception)
        : base(message, exception)
    {
        
    }
}