using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;
using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial class DatabaseBroker : IDatabaseBroker
    {
        private const string UserCollectionName = "Users";

        public DatabaseBroker(IServiceSettings serviceSettings)
        {
            var client = new MongoClient(serviceSettings.ConnectionString);
            var database = client.GetDatabase(serviceSettings.DatabaseName);

            _usersCollection = database.GetCollection<User>(UserCollectionName);
            
        }
    }
}