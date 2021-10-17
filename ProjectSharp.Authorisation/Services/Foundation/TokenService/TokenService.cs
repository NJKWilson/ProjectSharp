using System;
using System.Runtime.CompilerServices;
using ProjectSharp.Authorisation.Brokers.Token;
using ProjectSharp.Authorisation.Models.ApplicationUser;

namespace ProjectSharp.Authorisation.Services.Foundation.TokenService
{
    public class TokenService : TokenServiceBase, ITokenService
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
            TryCatch(
                () =>
                {
                    ValidateAudienceInput(audience);
                    ValidateApplicationUserModel(applicationUserModel);

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