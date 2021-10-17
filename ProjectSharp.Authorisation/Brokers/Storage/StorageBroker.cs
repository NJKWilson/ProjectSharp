using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Migrations;
using ProjectSharp.Authorisation.Models.ApplicationUser;

namespace ProjectSharp.Authorisation.Brokers.Storage
{
    public class StorageBroker
    {
        private const string UserCollectionName = "Users";

        private readonly IMongoCollection<ApplicationUserModel> _applicationUserCollection;

        public StorageBroker(ILogger logger, string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("project_sharp");

            _applicationUserCollection = database.GetCollection<ApplicationUserModel>(UserCollectionName);

            SeedCollectionIndexes.Seed(logger, _applicationUserCollection).Wait();
            SeedUsersAndRolesMigration.SeedAdminUser(logger, _applicationUserCollection, new PasswordBroker()).Wait();
        }
    }
}