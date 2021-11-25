using Microsoft.EntityFrameworkCore;
using ProjectSharp.Gui.Brokers.DateTime;
using ProjectSharp.Gui.Brokers.Password;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Users.Create.Exceptions;

namespace ProjectSharp.Gui.Features.Users.Create;

public class CreateUserFeature : ICreateUserFeature
{
    private readonly PSharpContext _pSharpContext;
    private readonly IDateTimeBroker _dateTimeBroker;
    private readonly IPasswordBroker _passwordBroker;

    public CreateUserFeature(
        PSharpContext pSharpContext, IDateTimeBroker dateTimeBroker, IPasswordBroker passwordBroker)
    {
        _pSharpContext = pSharpContext;
        _dateTimeBroker = dateTimeBroker;
        _passwordBroker = passwordBroker;
    }
    
    public async ValueTask<User> InsertAsync(string email, string password, User creatingUser)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(email)
            || string.IsNullOrWhiteSpace(password))
        {
            throw new CreateUserFeatureBadRequestException("Username or Password cannot be empty.");
        }
        
        // Check user does not exist.
        var maybeUser = await _pSharpContext.Users.FirstOrDefaultAsync(
            u => u.Email == email);
        if (maybeUser is not null)
            throw new CreateUserFeatureUserAlreadyExistsException(maybeUser);
        
        // Build the new user.
        var newUser = new User
        {
            Email = email,
            Password = _passwordBroker.HashPassword(password),
            Role = UserRole.Locked.ToString(),
            CreatedBy = creatingUser,
            CreatedOn = _dateTimeBroker.TimeNow()
        };

        // Try to save to database
        try
        {
            await _pSharpContext.Users.AddAsync(newUser);
            await _pSharpContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw new CreateUserFeatureDatabaseException("Database Exception", exception);
        }
        
        return newUser;
    }
}