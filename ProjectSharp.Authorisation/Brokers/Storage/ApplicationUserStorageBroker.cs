using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Brokers.Storage
{
    public class ApplicationUserStorageBroker : IApplicationUserStorageBroker
    {
        private readonly ILogger<ApplicationUserStorageBroker> _logger;
        private readonly IMongoCollection<ApplicationUserModel> _applicationUserCollection;
        private const string UserCollectionName = "Users";
        
        public ApplicationUserStorageBroker(
            ILogger<ApplicationUserStorageBroker> logger, IStorageBroker storageBroker, IPasswordBroker passwordBroker)
        {
            _logger = logger;

            _applicationUserCollection = 
                storageBroker.Database.GetCollection<ApplicationUserModel>(UserCollectionName);
        }
        
        public async Task CreateIndexOnEmail(CancellationToken cancellationToken)
        {
            var indexKeyDefinition = Builders<ApplicationUserModel>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<ApplicationUserModel>(indexKeyDefinition, indexOptions);

            await _applicationUserCollection.Indexes.CreateOneAsync(indexModel, cancellationToken: cancellationToken);
        }

        public async ValueTask InsertUserAsync(ApplicationUserModel user, CancellationToken cancellationToken)
        {
            await _applicationUserCollection.InsertOneAsync(user, cancellationToken: cancellationToken);
        }

        public async ValueTask<IEnumerable<ApplicationUserModel>> FindAllUsersAsync(CancellationToken cancellationToken)
        {
            var searchFilter = Builders<ApplicationUserModel>.Filter.Empty;
            return await _applicationUserCollection.Find(searchFilter)
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async ValueTask<ApplicationUserModel> FindUserByIdAsync(
            ObjectId userId, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<ApplicationUserModel>.Filter.Where(user => user.Id == userId);
            return await _applicationUserCollection.Find(searchFilter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async ValueTask<ApplicationUserModel> FindUserByEmailAsync(
            string userEmail, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<ApplicationUserModel>.Filter.Where(user => user.Email == userEmail);
            return await _applicationUserCollection.Find(searchFilter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async ValueTask<ApplicationUserModel> UpdateUserAsync(
            ApplicationUserModel updatedUser, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<ApplicationUserModel>.Filter.Where(user => user.Id == updatedUser.Id);
            var findOneReplaceOneOptions = new FindOneAndReplaceOptions<ApplicationUserModel>
            {
                IsUpsert = false,
                ReturnDocument = ReturnDocument.After
            };
            return await _applicationUserCollection
                .FindOneAndReplaceAsync(searchFilter, updatedUser, findOneReplaceOneOptions, cancellationToken);
        }

        public async ValueTask<ApplicationUserModel> DeleteUserAsync(
            ObjectId userId, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<ApplicationUserModel>.Filter
                .Where(user => user.Id == userId);
                
            return await _applicationUserCollection
                .FindOneAndDeleteAsync(searchFilter, cancellationToken: cancellationToken);
        }
    }
}