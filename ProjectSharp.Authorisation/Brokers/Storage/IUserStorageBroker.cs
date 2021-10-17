using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Brokers.Storage
{
    public interface IUserStorageBroker
    {
        Task CreateIndexOnEmail(CancellationToken cancellationToken);
        ValueTask InsertUserAsync(User user, CancellationToken cancellationToken);
        ValueTask<IEnumerable<User>> FindAllUsersAsync(CancellationToken cancellationToken);
        ValueTask<User> FindUserByIdAsync(ObjectId userId, CancellationToken cancellationToken);
        ValueTask<User> FindUserByEmailAsync(string userEmail, CancellationToken cancellationToken);
        ValueTask<User> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken);
        ValueTask<User> DeleteUserAsync(ObjectId userId, CancellationToken cancellationToken);
    }
}