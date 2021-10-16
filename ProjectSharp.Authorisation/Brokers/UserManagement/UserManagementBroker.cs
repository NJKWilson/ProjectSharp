using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Brokers.UserManagement
{
    public class UserManagementBroker : IUserManagementBroker
    {
        private readonly UserManager<User> _userManagement;

        public UserManagementBroker(UserManager<User> userManager)
        {
            _userManagement = userManager;
        }
        public IEnumerable<User> SelectAllUsers() => _userManagement.Users;

        public async ValueTask<User> SelectUserByIdAsync(Guid userId)
        {
            var broker = new UserManagementBroker(_userManagement);

            return await broker._userManagement.FindByIdAsync(userId.ToString());
        }

        public async ValueTask<User> InsertUserAsync(User user, string password)
        {
            var broker = new UserManagementBroker(_userManagement);
            await broker._userManagement.CreateAsync(user, password);

            return user;
        }

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            var broker = new UserManagementBroker(_userManagement);
            await broker._userManagement.UpdateAsync(user);

            return user;
        }

        public async ValueTask<User> DeleteUserAsync(User user)
        {
            var broker = new UserManagementBroker(_userManagement);
            await broker._userManagement.DeleteAsync(user);

            return user;
        }
    }
}