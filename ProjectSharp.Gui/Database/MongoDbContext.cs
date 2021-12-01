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
        
        SeedAdminUser();
    }

    private void SeedAdminUser()
    {
        // Check user does not exist.
        var searchFilter = Builders<User>.Filter.Where(u => u.Email == "admin@psharp.com");

        var maybeUser = Users.Find(searchFilter).FirstOrDefault();

        if (maybeUser is not null)
            return;
        
        var newUser = new User
        {
            FirstName = "Admin",
            LastName = "Psharp",
            JobTitle = "Administrator",
            Email = "admin@psharp.com",
            Password = "$2a$11$wavn.EqSjRjLzfaE9jsN6uRLgU51Uu6o39kZUOQld11HwF9En7imy",
            Role = UserRole.Admin.ToString(),
            CreatedBy = new User(){Email = "seed"},
            CreatedOn = DateTimeOffset.Now
        };


        Users.InsertOne(newUser);
    }
}