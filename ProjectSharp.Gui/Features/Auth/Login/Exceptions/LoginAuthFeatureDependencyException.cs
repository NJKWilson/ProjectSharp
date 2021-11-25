namespace ProjectSharp.Gui.Features.Auth.Login.Exceptions;

public class LoginAuthFeatureDependencyException : Exception
{
    public LoginAuthFeatureDependencyException(string message, Exception exception)
        : base(message, exception) { }
}