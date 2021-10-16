using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Brokers.UserManagement
{
    public interface IUserManagementBroker
    {
        ValueTask<User> InsertUserAsync(User user, string password);
        IEnumerable<User> SelectAllUsers();
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}