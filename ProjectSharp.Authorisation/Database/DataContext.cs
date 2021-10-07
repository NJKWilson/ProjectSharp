using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;
using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Database
{
    public class DataContext : IDataContext
    {
        private const string UserCollectionName = "Users";

        public DataContext(IServiceSettings serviceSettings)
        {
            var client = new MongoClient(serviceSettings.ConnectionString);
            var database = client.GetDatabase(serviceSettings.DatabaseName);

            Users = database.GetCollection<User>(UserCollectionName);

            //seedDataService.SeedAdminUser();
        }

        public IMongoCollection<User> Users { get; }
    }
}