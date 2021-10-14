using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Services.Foundation.UserService
{
    public interface IUserService
    {
        ValueTask RegisterUserAsync(User user, string password);
        ValueTask<User> RetrieveUserByIdAsync(Guid userId);
        IEnumerable<User> RetrieveAllUsers();
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<User> RemoveUserByIdAsync(Guid userId);
    }
}