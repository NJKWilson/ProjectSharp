using MongoDB.Driver;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Database;

public interface IMongoDbContext
{
    public IMongoCollection<User> Users { get; }
}