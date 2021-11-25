using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Auth;

// todo rename to AuthenticationState or AuthState
public class AuthenticationState
{
    // todo needs to get the user from the database everytime its requested
    public User? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;
    public bool IsAdmin => CurrentUser != null && CurrentUser.Role == UserRole.Admin.ToString();
    public bool IsUser => CurrentUser != null && CurrentUser.Role == UserRole.User.ToString();
    public bool IsLocked => CurrentUser != null && CurrentUser.Role == UserRole.Locked.ToString();
    public event Action? OnChange;

    public void LoginUser(User userToLogIn)
    {
        CurrentUser = userToLogIn;
    }

    public void LogoutUser()
    {
        CurrentUser = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}