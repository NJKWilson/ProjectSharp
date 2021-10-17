using ProjectSharp.Authorisation.Models.Token.Exceptions;
using ProjectSharp.Authorisation.Models.Users;

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
        
        public static void ValidateApplicationUserModel(ApplicationUserModel applicationUserModel)
        {
            
        }
    }
}