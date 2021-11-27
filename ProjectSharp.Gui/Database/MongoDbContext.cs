using MongoDB.Driver;
using ProjectSharp.Gui.Database.Configuration;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Database;

public class MongoDbContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }
    
    public MongoDbContext(IMongoDbSettings mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.ConnectionString);
        var database = client.GetDatabase(mongoDbSettings.DatabaseName);
        
        Users = database.GetCollection<User>(mongoDbSettings.UsersCollectionName);
    }
}