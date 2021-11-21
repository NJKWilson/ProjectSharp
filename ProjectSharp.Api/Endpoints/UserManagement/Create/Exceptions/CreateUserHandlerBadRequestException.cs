namespace ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;

public class CreateUserHandlerBadRequestException : Exception
{
    public CreateUserHandlerBadRequestException()
    : base("Bad request data")
    {
        
    }
}