using ProjectSharp.Authorisation.Models.ApplicationUser;
using ProjectSharp.Authorisation.Models.Token.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.TokenService
{
    public class TokenServiceValidations : TokenServiceExceptions
    {
        protected static void ValidateAudienceInput(string audience)
        {
            if (string.IsNullOrWhiteSpace(audience))
            {
                throw new TokenServiceValidationException("Audience empty");
            }
        }
        
        protected void ValidateApplicationUserModel(ApplicationUserModel applicationUserModel)
        {
            
        }
    }
}