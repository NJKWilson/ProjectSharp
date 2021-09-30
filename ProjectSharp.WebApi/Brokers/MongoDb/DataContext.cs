using MongoDB.Driver;
using ProjectSharp.WebApi.Configuration.MongoDb;
using ProjectSharp.WebApi.DbModel.ApplicationUser;

namespace ProjectSharp.WebApi.Brokers.MongoDb
{
    public class DataContext : IDataContext
    {
        public readonly IMongoCollection<User> Users;
        
        private const string UserCollectionName = "Users";
        
        public DataContext(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            Users = database.GetCollection<User>(UserCollectionName);
        }
    }
}