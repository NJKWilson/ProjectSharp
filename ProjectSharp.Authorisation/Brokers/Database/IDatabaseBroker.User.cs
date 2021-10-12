using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial interface IDatabaseBroker
    {
        Task CreateIndexOnEmail();
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<IEnumerable<User>> FindAllUsersAsync();
        ValueTask<User> FindUserByIdAsync(string userId);
        ValueTask<User> FindUserByEmailAsync(string userEmail);
        ValueTask<User> UpdateUserAsync(User updatedUser);
        ValueTask<User> DeleteUserAsync(string userId);
    }
}