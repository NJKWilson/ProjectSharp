using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Migrations
{
    public static class SeedCollectionIndexes
    {
        public static async Task Seed(
            ILogger logger, IMongoCollection<ApplicationUserModel> applicationUserCollection)
        {
            var indexKeyDefinition = Builders<ApplicationUserModel>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<ApplicationUserModel>(indexKeyDefinition, indexOptions);

            await applicationUserCollection.Indexes.CreateOneAsync(indexModel);
        }
    }
}