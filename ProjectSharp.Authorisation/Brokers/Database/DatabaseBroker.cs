using MongoDB.Driver;
using ProjectSharp.Authorisation.Brokers.Settings;
using ProjectSharp.Authorisation.Entities;
using ProjectSharp.Authorisation.Entities.User;
using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial class DatabaseBroker : IDatabaseBroker
    {
        private const string UserCollectionName = "Users";

        private readonly IMongoCollection<User> _usersCollection;

        public DatabaseBroker(ISettingsBroker settingsBroker)
        {
            var settings = settingsBroker.LoadSettings();
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usersCollection = database.GetCollection<User>(UserCollectionName);
        }
    }
}