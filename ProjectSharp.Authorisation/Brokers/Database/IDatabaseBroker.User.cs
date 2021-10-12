using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial interface IDatabaseBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<IEnumerable<User>> FindAllUsersAsync();
        ValueTask<User> FindUserByIdAsync(string userId);
        ValueTask<User> FindUserByEmailAsync(string userEmail);
        ValueTask<User> UpdateUserAsync(User updatedUser);
        ValueTask<User> DeleteUserAsync(string userId);
    }
}