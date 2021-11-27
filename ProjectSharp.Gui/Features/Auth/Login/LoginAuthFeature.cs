using MongoDB.Driver;
using ProjectSharp.Gui.Brokers.Password;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Auth.Login.Exceptions;

namespace ProjectSharp.Gui.Features.Auth.Login;

public class LoginAuthFeature : ILoginAuthFeature
{
    private readonly AuthenticationState _authenticationState;
    private readonly ILogger<LoginAuthFeature> _logger;
    private readonly IMongoDbContext _mongoDbContext;
    private readonly IPasswordBroker _passwordBroker;

    public LoginAuthFeature(
        ILogger<LoginAuthFeature> logger,
        IMongoDbContext mongoDbContext,
        IPasswordBroker passwordBroker,
        AuthenticationState authenticationState)
    {
        _logger = logger;
        _mongoDbContext = mongoDbContext;
        _passwordBroker = passwordBroker;
        _authenticationState = authenticationState;
    }

    public async ValueTask<User> Login(string email, string password)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            throw new LoginAuthFeatureBadRequest("Username or Password can not be empty.");

        // Check user does exist.
        var searchFilter = Builders<User>.Filter.Where(e => e.Email == email);

        User maybeUser;
        
        try
        {
            maybeUser = await _mongoDbContext.Users.Find(searchFilter).FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            throw new LoginAuthFeatureDatabaseException("Database exception while trying to retrieve User", exception);
        }
        
        if (maybeUser is null)
            throw new LoginAuthFeatureBadRequest("Username or Password is incorrect.");
        
        // Check password
        try
        {
            if (maybeUser.Password != null && !_passwordBroker.VerifyPassword(password, maybeUser.Password))
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