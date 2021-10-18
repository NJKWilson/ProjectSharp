using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Foundation.Users.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.Users
{
    public static class UserServiceValidations
    {
        public static void ValidateUserIdInput(ObjectId userId)
        {
            if (userId == ObjectId.Empty)
            {
                throw new UserServiceValidationException("User id empty");
            }
        }
        
        public static void ValidateUserEmailInput(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new UserServiceValidationException("Email empty");
            }
        }
        
        public static void ValidateUserInput(User user)
        {
            if (user is null)
            {
                throw new UserServiceValidationException("User is empty");
            }
            
            if (user.Id == ObjectId.Empty)
            {
                throw new UserServiceValidationException("User id is empty");
            }
            
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new UserServiceValidationException("Email empty");
            }
            
            if (string.IsNullOrWhiteSpace(user.Role))
            {
                throw new UserServiceValidationException("Role empty");
            }
        }
    }
}