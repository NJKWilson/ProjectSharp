using System;
using ProjectSharp.Authorisation.Brokers.Token;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Foundation.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly ITokenBroker _tokenBroker;
        private const int ExpiryDurationMinutes = 30;
        private string _jwtSigningKey;
        private string _issuer;

        public TokenService(ITokenBroker tokenBroker)
        {
            _tokenBroker = tokenBroker;
            _jwtSigningKey = Guid.NewGuid().ToString();
            _issuer = Guid.NewGuid().ToString();
        }

        public string BuildToken(string audience, ApplicationUserModel applicationUserModel) =>
            TokenServiceExceptions.TryCatch(
                () =>
                {
                    TokenServiceValidations.ValidateAudienceInput(audience);
                    TokenServiceValidations.ValidateApplicationUserModel(applicationUserModel);

                    return _tokenBroker.BuildToken(_issuer, audience, _jwtSigningKey, ExpiryDurationMinutes,
                        applicationUserModel);
                }
            );

        public string VerifyToken(string audience, string token)
        {
            throw new NotImplementedException();
        }

        public void ChangeJwtSigningKey()
        {
            _jwtSigningKey = Guid.NewGuid().ToString();
            _issuer = Guid.NewGuid().ToString();
        }
    }
}