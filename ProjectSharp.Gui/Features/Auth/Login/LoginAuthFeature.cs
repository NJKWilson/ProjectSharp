using Microsoft.EntityFrameworkCore;
using ProjectSharp.Gui.Brokers.Password;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Auth.Login.Exceptions;

namespace ProjectSharp.Gui.Features.Auth.Login;

public class LoginAuthFeature : ILoginAuthFeature
{
    private readonly AuthenticationState _authenticationState;
    private readonly ILogger<LoginAuthFeature> _logger;
    private readonly IPasswordBroker _passwordBroker;
    private readonly PSharpContext _pSharpContext;

    public LoginAuthFeature(
        ILogger<LoginAuthFeature> logger,
        PSharpContext pSharpContext,
        IPasswordBroker passwordBroker,
        AuthenticationState authenticationState)
    {
        _logger = logger;
        _pSharpContext = pSharpContext;
        _passwordBroker = passwordBroker;
        _authenticationState = authenticationState;
    }

    public async ValueTask<User> Login(string email, string password)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            throw new LoginAuthFeatureBadRequest("Username or Password can not be empty.");

        // Check user does exist.
        var maybeUser = await _pSharpContext.Users.FirstOrDefaultAsync(
            u => u.Email == email);
        if (maybeUser is null)
            throw new LoginAuthFeatureBadRequest("Username or Password is incorrect.");
        // Check password
        try
        {
            if (!_passwordBroker.VerifyPassword(password, maybeUser.Password))
                throw new LoginAuthFeatureBadRequest("Username or Password is incorrect.");
        }
        catch (Exception exception)
        {
            throw new LoginAuthFeatureDependencyException("Password hashing Exception", exception);
        }

        // Set the current user
        _authenticationState.LoginUser(maybeUser);

        return maybeUser;
    }
}