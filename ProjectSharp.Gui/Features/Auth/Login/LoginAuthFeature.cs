using ProjectSharp.Gui.Core.States.CurrentUser;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Auth.Login;

public class LoginAuthFeature : ILoginAuthFeature
{
    private readonly ILogger<LoginAuthFeature> _logger;
    private readonly PSharpContext _pSharpContext;
    private readonly CurrentUserCoreState _currentUserCoreState;

    public LoginAuthFeature(
        ILogger<LoginAuthFeature> logger, PSharpContext pSharpContext, CurrentUserCoreState currentUserCoreState)
    {
        _logger = logger;
        _pSharpContext = pSharpContext;
        _currentUserCoreState = currentUserCoreState;
    }

    public ValueTask<User> Login(string username, string password)
    {
        var testUser = new User
        {
            Role = UserRole.Admin.ToString()
        };
        
        _currentUserCoreState.LoginUser(testUser);
        
        return ValueTask.FromResult(testUser);
    }
}