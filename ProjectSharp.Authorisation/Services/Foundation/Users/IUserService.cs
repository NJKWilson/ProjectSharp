using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Foundation.Users
{
    public interface IUserService
    {
        ValueTask CreateIndexOnEmail(CancellationToken cancellationToken = default);
        ValueTask CreateUserAsync(User user, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        ValueTask<User> GetUserByIdAsync(ObjectId userId, CancellationToken cancellationToken = default);
        ValueTask<User> GetUserByEmailAsync(string userEmail, CancellationToken cancellationToken = default);
        ValueTask<User> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken = default);
        ValueTask<User> RemoveUserAsync(ObjectId userId, CancellationToken cancellationToken = default);
    }
}