using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Orchestration.UserManagement.Exceptions;

namespace ProjectSharp.Authorisation.Services.Orchestration.UserManagement
{
    public static class UserManagementServiceValidations
    {
        public static void ValidateCreateUserInput(User user, string password)
        {
            ValidateUser("Create User Validate input :", user);
            
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new UserManagementServiceValidationException(
                    "Create User Validate input : User Password empty");
            }
        }
        
        public static void ValidateCreateUserOutput(User user)
        {
            ValidateUser("Create User Validate output :", user);
        }

        public static void ValidateUpdateUserInput(User user)
        {
            ValidateUser("Update User Validate input :", user);
        }
        
        public static void ValidateUpdateUserOutput(User user)
        {
            ValidateUser("Update User Validate output :", user);
        }
        
        public static void ValidateLockOutUserInput(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new UserManagementServiceValidationException("Lock Out User Input : Id is empty");
            }
        }
        
        public static void ValidateLockOutUserOutput(User maybeUser)
        {
            if (maybeUser is null)
            {
                // todo needs null exception
                throw new UserManagementServiceValidationException("Lock Out User Output : User was null");
            }
        }
        
        public static void ValidateResetPasswordInput(string userId, string password)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new UserManagementServiceValidationException("Reset Password Input : userId was empty");
            }
            
            if (string.IsNullOrEmpty(password))
            {
                throw new UserManagementServiceValidationException("Reset Password Input : Password was empty");
            }
        }
        
        public static void ValidateLoginInput(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new UserManagementServiceValidationException("Login Input : Email was empty");
            }
            
            if (string.IsNullOrEmpty(password))
            {
                throw new UserManagementServiceValidationException("Login Input : Password was empty");
            }
        }
        
        public static void ValidateLoginOutput(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new UserManagementServiceValidationException("Login Output : Token was empty");
            }
        }
        
        public static void ValidateVerifyTokenInput(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new UserManagementServiceValidationException("Verify Token Input : Token was empty");
            }
        }
        
        public static void ValidateVerifyTokenOutput(bool result)
        {
            if (!result)
            {
                // todo need token failed exception
                throw new UserManagementServiceValidationException(
                    "Verify Token Output : failed to verify token");
            }
        }
        
        private static void ValidateUser(string identifier, User user)
        {
            if (user is null)
            {
                throw new UserManagementServiceValidationException($"{identifier} Output User empty");
            }
            
            if (user.Id == ObjectId.Empty)
            {
                throw new UserManagementServiceValidationException($"{identifier} User Id empty");
            }
            
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new UserManagementServiceValidationException($"{identifier} User Email empty");
            }
            
            if (string.IsNullOrWhiteSpace(user.Role))
            {
                throw new UserManagementServiceValidationException($"{identifier} User Role empty");
            }
        }
    }
}