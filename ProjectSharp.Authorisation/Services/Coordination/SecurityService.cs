using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Foundation.Passwords;
using ProjectSharp.Authorisation.Services.Foundation.Tokens;

namespace ProjectSharp.Authorisation.Services.Coordination
{
    public class SecurityService : ISecurityService
    {
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public SecurityService(ITokenService tokenService, IPasswordService passwordService)
        {
            _tokenService = tokenService;
            _passwordService = passwordService;
        }
        
        public string BuildToken(string audience, User user)
        {
            return _tokenService.BuildToken(audience, user);
        }

        public string VerifyToken(string audience, string token)
        {
            return _tokenService.VerifyToken(audience, token);
        }

        public void ChangeJwtSigningKey()
        {
            _tokenService.ChangeJwtSigningKey();
        }

        public string HashPassword(string password)
        {
            return _passwordService.HashPassword(password);
        }

        public bool VerifyPassword(string passwordHash, string password)
        {
            return _passwordService.VerifyPassword(passwordHash, password);
        }
    }
}