using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.ApplicationUser;

namespace ProjectSharp.Authorisation.Brokers.Storage
{
    public interface IApplicationUserStorageBroker
    {
        Task CreateIndexOnEmail(CancellationToken cancellationToken);
        ValueTask InsertUserAsync(ApplicationUserModel user, CancellationToken cancellationToken);
        ValueTask<IEnumerable<ApplicationUserModel>> FindAllUsersAsync(CancellationToken cancellationToken);
        ValueTask<ApplicationUserModel> FindUserByIdAsync(ObjectId userId, CancellationToken cancellationToken);
        ValueTask<ApplicationUserModel> FindUserByEmailAsync(string userEmail, CancellationToken cancellationToken);
        ValueTask<ApplicationUserModel> UpdateUserAsync(ApplicationUserModel updatedUser, CancellationToken cancellationToken);
        ValueTask<ApplicationUserModel> DeleteUserAsync(ObjectId userId, CancellationToken cancellationToken);
    }
}