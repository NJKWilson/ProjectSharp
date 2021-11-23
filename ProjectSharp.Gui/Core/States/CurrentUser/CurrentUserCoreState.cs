using ProjectSharp.Gui.Database.Entities;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Database.Enums;

namespace ProjectSharp.Gui.Core.States.CurrentUser;

public class CurrentUserCoreState
{
    public User? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null ? true : false;
    public bool IsAdmin => CurrentUser != null && (CurrentUser.Role == UserRole.Admin.ToString() ? true : false);
    public bool IsUser => CurrentUser != null && (CurrentUser.Role == UserRole.User.ToString() ? true : false);
    public bool IsLocked => CurrentUser != null && (CurrentUser.Role == UserRole.Locked.ToString() ? true : false);

    public void LoginUser(User userToLogIn)
    {
        CurrentUser = userToLogIn;
    }
    
    public void LogoutUser()
    {
        CurrentUser = null;
    }
}