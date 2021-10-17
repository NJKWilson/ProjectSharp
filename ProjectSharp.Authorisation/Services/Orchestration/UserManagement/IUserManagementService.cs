using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Orchestration.UserManagement
{
    public interface IUserManagementService
    {
        ValueTask<User> CreateUser(User user, string password, CancellationToken cancellationToken);
        ValueTask<User> UpdateUser(User user, CancellationToken cancellationToken);
        ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
        ValueTask<User> LockoutUser(string userId, CancellationToken cancellationToken);
        ValueTask<bool> ResetPassword(string userId, string password, CancellationToken cancellationToken);
        ValueTask<string> Login(string user, string password, CancellationToken cancellationToken);
        ValueTask<bool> VerifyToken(string password, CancellationToken cancellationToken);
    }
}