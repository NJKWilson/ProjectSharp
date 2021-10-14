using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial class DatabaseBroker
    {
        public async Task CreateIndexOnEmail()
        {
            var indexKeyDefinition = Builders<User>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<User>(indexKeyDefinition, indexOptions);

            await _usersCollection.Indexes.CreateOneAsync(indexModel);
        }

        public async ValueTask InsertUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async ValueTask<IEnumerable<User>> FindAllUsersAsync()
        {
            var searchFilter = Builders<User>.Filter.Empty;
            return await _usersCollection.Find(searchFilter).ToListAsync();
        }

        public async ValueTask<User> FindUserByIdAsync(string userId)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Id == ObjectId.Parse(userId));
            return await _usersCollection.Find(searchFilter).FirstOrDefaultAsync();
        }

        public async ValueTask<User> FindUserByEmailAsync(string userEmail)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Email == userEmail);
            return await _usersCollection.Find(searchFilter).FirstOrDefaultAsync();
        }

        public async ValueTask<User> UpdateUserAsync(User updatedUser)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Id == updatedUser.Id);
            var findOneReplaceOneOptions = new FindOneAndReplaceOptions<User>
            {
                IsUpsert = false,
                ReturnDocument = ReturnDocument.After
            };
            return await _usersCollection.FindOneAndReplaceAsync(searchFilter, updatedUser, findOneReplaceOneOptions);
        }

        public async ValueTask<User> DeleteUserAsync(string userId)
        {
            var searchFilter = Builders<User>.Filter.Where(user => user.Id == ObjectId.Parse(userId));
            return await _usersCollection.FindOneAndDeleteAsync(searchFilter);
        }
    }
}