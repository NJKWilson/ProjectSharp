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
    public class UserStorageBroker : IUserStorageBroker
    {
        private readonly ILogger<UserStorageBroker> _logger;
        private readonly IMongoCollection<User> _userCollection;
        private const string UserCollectionName = "Users";
        
        public UserStorageBroker(
            ILogger<UserStorageBroker> logger, IStorageBroker storageBroker, IPasswordBroker passwordBroker)
        {
            _logger = logger;

            _userCollection = 
                storageBroker.Database.GetCollection<User>(UserCollectionName);
        }
        
        public async Task CreateIndexOnEmail(CancellationToken cancellationToken)
        {
            var indexKeyDefinition = Builders<User>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<User>(indexKeyDefinition, indexOptions);

            await _userCollection.Indexes.CreateOneAsync(indexModel, cancellationToken: cancellationToken);
        }

        public async ValueTask InsertUserAsync(User user, CancellationToken cancellationToken)
        {
            await _userCollection.InsertOneAsync(user, cancellationToken: cancellationToken);
        }

        public async ValueTask<IEnumerable<User>> FindAllUsersAsync(CancellationToken cancellationToken)
        {
            var searchFilter = Builders<User>.Filter.Empty;
            return await _userCollection.Find(searchFilter)
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async ValueTask<User> FindUserByIdAsync(
            ObjectId userId, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Id == userId);
            return await _userCollection.Find(searchFilter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async ValueTask<User> FindUserByEmailAsync(
            string userEmail, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Email == userEmail);
            return await _userCollection.Find(searchFilter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async ValueTask<User> UpdateUserAsync(
            User updatedUser, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Id == updatedUser.Id);
            var findOneReplaceOneOptions = new FindOneAndReplaceOptions<User>
            {
                IsUpsert = false,
                ReturnDocument = ReturnDocument.After
            };
            return await _userCollection
                .FindOneAndReplaceAsync(searchFilter, updatedUser, findOneReplaceOneOptions, cancellationToken);
        }

        public async ValueTask<User> DeleteUserAsync(
            ObjectId userId, CancellationToken cancellationToken)
        {
            var searchFilter = Builders<User>.Filter
                .Where(user => user.Id == userId);
                
            return await _userCollection
                .FindOneAndDeleteAsync(searchFilter, cancellationToken: cancellationToken);
        }
    }
}