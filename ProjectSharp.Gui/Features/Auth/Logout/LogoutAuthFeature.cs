namespace ProjectSharp.Gui.Features.Auth.Logout;

public class LogoutAuthFeature : ILogoutAuthFeature
{
    private readonly AuthenticationState _authenticationState;

    public LogoutAuthFeature(AuthenticationState authenticationState)
    {
        _authenticationState = authenticationState;
    }
    public void Logout()
    {
        _authenticationState.LogoutUser();
    }
}