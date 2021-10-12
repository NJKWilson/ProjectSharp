using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial class DatabaseBroker
    {
        public async ValueTask<User> InsertUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return await FindUserByEmailAsync(user.Email);
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