namespace ProjectSharp.Gui.Features.Auth.Login.Exceptions;

public class LoginAuthFeatureBadRequest : Exception
{
    public LoginAuthFeatureBadRequest(string message)
     : base(message) { }
}