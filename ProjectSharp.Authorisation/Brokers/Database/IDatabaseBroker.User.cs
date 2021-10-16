using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial interface IDatabaseBroker
    {
        Task CreateIndexOnEmail();
        ValueTask InsertUserAsync(User user);
        ValueTask<IEnumerable<User>> FindAllUsersAsync();
        ValueTask<User> FindUserByIdAsync(Guid userId);
        ValueTask<User> FindUserByEmailAsync(string userEmail);
        ValueTask<User> UpdateUserAsync(User updatedUser);
        ValueTask<User> DeleteUserAsync(Guid userId);
    }
}