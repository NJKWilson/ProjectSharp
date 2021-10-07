using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial class DatabaseBroker
    {
        private IMongoCollection<User> _usersCollection;
        
        public ValueTask<User> InsertUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> SelectUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}