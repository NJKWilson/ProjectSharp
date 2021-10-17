using MongoDB.Bson;
using ProjectSharp.Authorisation.Models.Token.Exceptions;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Foundation.Tokens.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.Tokens
{
    public static class TokenServiceValidations
    {
        public static void ValidateAudienceInput(string audience)
        {
            if (string.IsNullOrWhiteSpace(audience))
            {
                throw new TokenServiceValidationException("Audience empty");
            }
        }
        
        public static void ValidateUserInput(User user)
        {
            if (user is null)
            {
                throw new TokenServiceValidationException("User is empty");
            }
            
            if (user.Id == ObjectId.Empty)
            {
                throw new TokenServiceValidationException("User id is empty");
            }
            
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new TokenServiceValidationException("Email empty");
            }
            
            if (string.IsNullOrWhiteSpace(user.Role))
            {
                throw new TokenServiceValidationException("Role empty");
            }
        }
        
        public static void ValidateTokenInput(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new TokenServiceValidationException("Token empty");
            }
        }
    }
}