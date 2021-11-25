namespace ProjectSharp.Gui.Features.Auth.Login.Exceptions;

public class LoginAuthFeatureDatabaseException : Exception
{
    public LoginAuthFeatureDatabaseException(string message, Exception exception)
        : base(message, exception)
    {
    }
}