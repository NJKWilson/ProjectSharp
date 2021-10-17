using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Brokers.Token
{
    public interface ITokenBroker
    {
        /// <summary>
        /// Builds a token.
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="expiryDurationMinutes"></param>
        /// <param name="user"></param>
        /// <param name="audience"></param>
        /// <param name="jwtSigningKey"></param>
        /// <returns></returns>
        string BuildToken(
            string issuer, 
            string audience, 
            string jwtSigningKey, 
            int expiryDurationMinutes,
            ApplicationUserModel user);

        /// <summary>
        /// Validates a token and returns the user id if valid
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="audience"></param>
        /// <param name="jwtSigningKey"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        string ValidateToken(string issuer, string audience, string jwtSigningKey, string token);

    }
}