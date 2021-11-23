namespace ProjectSharp.Gui.Features.Users.Create.Exceptions;

public class CreateUserFeatureBadRequestException : Exception
{
    public CreateUserFeatureBadRequestException(string message)
        : base(message) { }
}