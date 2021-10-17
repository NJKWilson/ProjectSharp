using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace ProjectSharp.Authorisation.Brokers.Storage
{
    public class StorageBroker
    {
        public IMongoDatabase Database { get; }

        public StorageBroker(ILogger logger, string connectionString)
        {
            var client = new MongoClient(connectionString);
            Database = client.GetDatabase("project_sharp");
        }
    }
}