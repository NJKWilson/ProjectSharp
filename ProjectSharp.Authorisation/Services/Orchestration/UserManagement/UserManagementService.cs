using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Coordination;
using ProjectSharp.Authorisation.Services.Foundation.Users;

namespace ProjectSharp.Authorisation.Services.Orchestration.UserManagement
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;

        public UserManagementService(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        public ValueTask<User> CreateUser(User user, string password, CancellationToken cancellationToken) =>
            UserManagementServiceExceptions.TryCatch(
                async () =>
                {
                    UserManagementServiceValidations.ValidateCreateUserInput(user, password);
                    
                    user.PasswordHash = _securityService.HashPassword(password);

                    await _userService.CreateUserAsync(user, cancellationToken);

                    var maybeUser = await _userService.GetUserByEmailAsync(user.Email, cancellationToken);
                    
                    UserManagementServiceValidations.ValidateCreateUserOutput(maybeUser);
                    
                    return maybeUser;
                });

        public ValueTask<User> UpdateUser(User user, CancellationToken cancellationToken) =>
            UserManagementServiceExceptions.TryCatch(
                async () =>
                {
                    UserManagementServiceValidations.ValidateUpdateUserInput(user);

                    var maybeUserToUpdate = await _userService.GetUserByIdAsync(user.Id, cancellationToken);
                    
                    //todo needs its own validator
                    UserManagementServiceValidations.ValidateUpdateUserInput(maybeUserToUpdate);

                    maybeUserToUpdate.Email = user.Email;
                    maybeUserToUpdate.Role = user.Role;
                    maybeUserToUpdate.Locked = user.Locked;

                    var result = await _userService.UpdateUserAsync(maybeUserToUpdate, cancellationToken);
                    
                    UserManagementServiceValidations.ValidateUpdateUserOutput(result);
                    
                    return result;
                });

        public ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken) =>
            UserManagementServiceExceptions.TryCatch(async () => 
                await _userService.GetAllUsersAsync(cancellationToken));

        public ValueTask<User> LockoutUser(string userId, CancellationToken cancellationToken) =>
            UserManagementServiceExceptions.TryCatch(
                async () =>
                {
                    UserManagementServiceValidations.ValidateLockOutUserInput(userId);

                    var maybeUserToUpdate = 
                        await _userService.GetUserByIdAsync(ObjectId.Parse(userId), cancellationToken);
                    
                    //todo needs its own validator
                    UserManagementServiceValidations.ValidateLockOutUserOutput(maybeUserToUpdate);
                    
                    maybeUserToUpdate.Locked = !maybeUserToUpdate.Locked;

                    var result = await _userService.UpdateUserAsync(maybeUserToUpdate, cancellationToken);
                    
                    UserManagementServiceValidations.ValidateLockOutUserOutput(result);
                    
                    return result;
                });

        public ValueTask<bool> ResetPassword(string userId, string password, CancellationToken cancellationToken) =>
            UserManagementServiceExceptions.TryCatch(
                async () =>
                {
                    UserManagementServiceValidations.ValidateResetPasswordInput(userId, password);

                    var maybeUserToUpdate = 
                        await _userService.GetUserByIdAsync(ObjectId.Parse(userId), cancellationToken);
                    
                    //todo needs its own validator
                    UserManagementServiceValidations.ValidateLockOutUserOutput(maybeUserToUpdate);
                    
                    maybeUserToUpdate.PasswordHash = _securityService.HashPassword(password);
                    
                    return true;
                });

        public ValueTask<string> Login(string email, string password, CancellationToken cancellationToken) =>
            UserManagementServiceExceptions.TryCatch(
                async () =>
                {
                    UserManagementServiceValidations.ValidateLoginInput(email, password);

                    var maybeUserToUpdate = 
                        await _userService.GetUserByEmailAsync(email, cancellationToken);
                    
                    //todo needs its own validator
                    UserManagementServiceValidations.ValidateLockOutUserOutput(maybeUserToUpdate);

                    var result = _securityService.VerifyPassword(maybeUserToUpdate.PasswordHash, password);

                    if (!result)
                        return "";

                    return _securityService.BuildToken("temp", maybeUserToUpdate);
                });

        public ValueTask<bool> VerifyToken(string token, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}