using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Api.Brokers.JwtToken;

public interface IJwtTokenBroker
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
    string BuildToken(string issuer, string audience, string jwtSigningKey, int expiryDurationMinutes, User user);

    /// <summary>
    /// Validates a token and returns the user id if valid
    /// </summary>
    /// <param name="issuer"></param>
    /// <param name="audience"></param>
    /// <param name="jwtSigningKey"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Guid ValidateToken(string issuer, string audience, string jwtSigningKey, string token);
}