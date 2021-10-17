using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Brokers.Storage;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Foundation.Users
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserStorageBroker _userStorageBroker;

        public UserService(ILogger<UserService> logger, IUserStorageBroker userStorageBroker)
        {
            _logger = logger;
            _userStorageBroker = userStorageBroker;
        }

        public ValueTask CreateIndexOnEmail(CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(async () =>
                await _userStorageBroker.CreateIndexOnEmail(cancellationToken));

        public ValueTask CreateUserAsync(User user, CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(
                async () =>
                {
                    UserServiceValidations.ValidateUserInput(user);

                    await _userStorageBroker.InsertUserAsync(user, cancellationToken);
                }
            );

        public ValueTask<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(async () =>
                await _userStorageBroker.FindAllUsersAsync(cancellationToken));

        public ValueTask<User> GetUserByIdAsync(ObjectId userId, CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(
                async () =>
                {
                    UserServiceValidations.ValidateUserIdInput(userId);

                    return await _userStorageBroker.FindUserByIdAsync(userId, cancellationToken);
                }
            );

        public ValueTask<User> GetUserByEmailAsync(string userEmail, CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(
                async () =>
                {
                    UserServiceValidations.ValidateUserEmailInput(userEmail);

                    return await _userStorageBroker.FindUserByEmailAsync(userEmail, cancellationToken);
                }
            );

        public ValueTask<User> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(
                async () =>
                {
                    UserServiceValidations.ValidateUserInput(updatedUser);

                    return await _userStorageBroker.UpdateUserAsync(updatedUser, cancellationToken);
                }
            );

        public ValueTask<User> RemoveUserAsync(ObjectId userId, CancellationToken cancellationToken) =>
            UserServiceExceptions.TryCatch(
                async () =>
                {
                    UserServiceValidations.ValidateUserIdInput(userId);

                    return await _userStorageBroker.DeleteUserAsync(userId, cancellationToken);
                }
            );
    }
}