namespace ProjectSharp.Gui.Features.Users.Create.Exceptions;

public class CreateUserFeatureDatabaseException : Exception
{
    public CreateUserFeatureDatabaseException(string message, Exception exception)
        : base(message, exception) { }
}