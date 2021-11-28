using MongoDB.Driver;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Users.GetAll;

public class GetAllUsersFeature : IGetAllUsersFeature
{
    private readonly IMongoDbContext _mongoDbContext;

    public GetAllUsersFeature(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    public async ValueTask<IEnumerable<User>> GetAll()
    {
        var searchFilter = Builders<User>.Filter.Empty;
        return await _mongoDbContext.Users.Find(searchFilter).ToListAsync();
    }
}