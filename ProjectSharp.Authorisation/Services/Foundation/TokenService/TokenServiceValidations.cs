using ProjectSharp.Authorisation.Models.ApplicationUser;
using ProjectSharp.Authorisation.Models.Token.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.TokenService
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