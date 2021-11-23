using ProjectSharp.DataAccess.Entities;
using ProjectSharp.DataAccess.Enums;
using User = ProjectSharp.Gui.Database.Entities.User;
using UserRole = ProjectSharp.Gui.Database.Enums.UserRole;

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