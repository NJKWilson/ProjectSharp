using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Foundation.Users
{
    public interface IUserService
    {
        ValueTask CreateIndexOnEmail(CancellationToken cancellationToken);
        ValueTask CreateUserAsync(User user, CancellationToken cancellationToken);
        ValueTask<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        ValueTask<User> GetUserByIdAsync(ObjectId userId, CancellationToken cancellationToken);
        ValueTask<User> GetUserByEmailAsync(string userEmail, CancellationToken cancellationToken);
        ValueTask<User> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken);
        ValueTask<User> RemoveUserAsync(ObjectId userId, CancellationToken cancellationToken);
    }
}