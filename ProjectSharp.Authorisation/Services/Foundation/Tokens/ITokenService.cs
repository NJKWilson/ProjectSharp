using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Foundation.Tokens
{
    public interface ITokenService
    {
        /// <summary>
        /// Builds a token.
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        string BuildToken(string audience, User user);

        /// <summary>
        /// Validates a token and returns the user id if valid
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        string VerifyToken(string audience, string token);
        
        /// <summary>
        /// Kill switch, invalidates all tokens
        /// </summary>
        /// <returns></returns>
        void ChangeJwtSigningKey();
    }
}