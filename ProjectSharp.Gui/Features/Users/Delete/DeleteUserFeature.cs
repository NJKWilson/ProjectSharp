using MongoDB.Driver;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Users.Delete.Exceptions;

namespace ProjectSharp.Gui.Features.Users.Delete;

public class DeleteUserFeature : IDeleteUserFeature
{
    private readonly IMongoDbContext _mongoDbContext;

    public DeleteUserFeature(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    public async ValueTask<User> DeleteAsync(User user)
    {
        // Validation
        if (user.Id == Guid.Empty)
            throw new DeleteUserFeatureBadRequestException();

        // Check user does exist.
        var searchFilter = Builders<User>.Filter.Where(u => u.Id == user.Id);
        var maybeUser = await _mongoDbContext.Users.Find(searchFilter).FirstOrDefaultAsync();

        if (maybeUser is null)
            throw new DeleteUserFeatureUserDoesNotExistException();

        // Try to save to database
        try
        {
            var deleteFilter = Builders<User>.Filter.Where(u => u.Id == user.Id);
            await _mongoDbContext.Users.DeleteOneAsync(deleteFilter);
        }
        catch (Exception exception)
        {
            throw new DeleteUserFeatureDatabaseException($"Database exception while trying to delete {user.Email}", exception);
        }

        return maybeUser;
    }
}