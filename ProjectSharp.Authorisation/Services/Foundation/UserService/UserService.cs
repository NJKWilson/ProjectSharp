using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Brokers.Database;
using ProjectSharp.Authorisation.Brokers.Logging;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Services.Foundation.UserService
{
    public partial class UserService : IUserService
    {
        private readonly ILoggingBroker _loggingBroker;
        private readonly IDatabaseBroker _databaseBroker;

        public UserService(ILoggingBroker loggingBroker, IDatabaseBroker databaseBroker)
        {
            _loggingBroker = loggingBroker;
            _databaseBroker = databaseBroker;
        }

        public ValueTask RegisterUserAsync(User user, string password) =>
            TryCatch(async () =>
            {
                ValidateUser(user);
                await _databaseBroker.InsertUserAsync(user);
            });

        public ValueTask<User> RetrieveUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> RetrieveAllUsers()
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> ModifyUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> RemoveUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}