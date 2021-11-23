using Microsoft.EntityFrameworkCore;
using ProjectSharp.DataAccess;
using ProjectSharp.DataAccess.Entities;
using ProjectSharp.DataAccess.Enums;
using ProjectSharp.Gui.Core.Brokers.DateTime;
using ProjectSharp.Gui.Core.Brokers.Password;
using ProjectSharp.Gui.Features.Users.Create.Exceptions;
using PSharpContext = ProjectSharp.Gui.Database.PSharpContext;
using User = ProjectSharp.Gui.Database.Entities.User;
using UserRole = ProjectSharp.Gui.Database.Enums.UserRole;

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
    
    public async ValueTask<User> InsertAsync(CreateUserFeatureRequest createUserFeatureRequest)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(createUserFeatureRequest.Email)
            || string.IsNullOrWhiteSpace(createUserFeatureRequest.Password))
        {
            throw new CreateUserFeatureBadRequestException("Username or Password cannot be empty.");
        }
        
        // Check user does not exist.
        var maybeUser = await _pSharpContext.Users.FirstOrDefaultAsync(
            u => u.Email == createUserFeatureRequest.Email);
        if (maybeUser is not null)
            throw new CreateUserFeatureUserAlreadyExistsException(maybeUser);
        
        // Build the new user.
        var newUser = new User
        {
            Email = createUserFeatureRequest.Email,
            Password = _passwordBroker.HashPassword(createUserFeatureRequest.Password),
            Role = UserRole.Locked.ToString(),
            CreatedBy = createUserFeatureRequest.CreatingUser,
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