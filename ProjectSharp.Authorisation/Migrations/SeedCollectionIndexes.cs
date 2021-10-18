using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Migrations
{
    public static class SeedCollectionIndexes
    {
        public static async Task Seed(
            ILogger logger, IMongoCollection<User> applicationUserCollection)
        {
            var indexKeyDefinition = Builders<User>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<User>(indexKeyDefinition, indexOptions);

            await applicationUserCollection.Indexes.CreateOneAsync(indexModel);
        }
    }
}