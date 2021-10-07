using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public partial interface IDatabaseBroker
    {
        ValueTask<User> InsertUserAsync(User user);

        IEnumerable<User> SelectAllUsersAsync();

        ValueTask<User> SelectUserByIdAsync(string userId);

        ValueTask<User> UpdateUserAsync(User user);

        ValueTask<User> DeleteUserAsync(User user);
    }
}