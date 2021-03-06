using MongoDB.Driver;
using ProjectSharp.Gui.Brokers.DateTime;
using ProjectSharp.Gui.Brokers.Password;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Users.Create.Exceptions;

namespace ProjectSharp.Gui.Features.Users.Create;

public class CreateUserFeature : ICreateUserFeature
{
    private readonly IMongoDbContext _mongoDbContext;
    private readonly IDateTimeBroker _dateTimeBroker;
    private readonly IPasswordBroker _passwordBroker;

    public CreateUserFeature(
        IMongoDbContext mongoDbContext, IDateTimeBroker dateTimeBroker, IPasswordBroker passwordBroker)
    {
        _mongoDbContext = mongoDbContext;
        _dateTimeBroker = dateTimeBroker;
        _passwordBroker = passwordBroker;
    }

    public async ValueTask<User> InsertAsync(CreateUserFeatureRequest createUserFeatureRequest, User creatingUser)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(createUserFeatureRequest.Email) || string.IsNullOrWhiteSpace(createUserFeatureRequest.Password))
            throw new CreateUserFeatureBadRequestException("Username or Password cannot be empty.");

        // Check user does not exist.
        var searchFilter = Builders<User>.Filter.Where(u => u.Email == createUserFeatureRequest.Email);

        var maybeUser = await _mongoDbContext.Users.Find(searchFilter).FirstOrDefaultAsync();
        
        if (maybeUser is not null)
            throw new CreateUserFeatureUserAlreadyExistsException(maybeUser);

        // Build the new user.
        var newUser = new User
        {
            FirstName = createUserFeatureRequest.FirstName,
            LastName = createUserFeatureRequest.LastName,
            JobTitle = createUserFeatureRequest.JobTitle,
            Email = createUserFeatureRequest.Email,
            Password = _passwordBroker.HashPassword(createUserFeatureRequest.Password),
            Role = UserRole.Locked.ToString(),
            CreatedBy = creatingUser,
            CreatedOn = _dateTimeBroker.TimeNow()
        };

        // Try to save to database
        try
        {
            await _mongoDbContext.Users.InsertOneAsync(newUser);
        }
        catch (Exception exception)
        {
            throw new CreateUserFeatureDatabaseException("Database exception while trying to insert User", exception);
        }

        return newUser;
    }
}