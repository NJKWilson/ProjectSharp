using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjectSharp.Api.Brokers.DateTime;
using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Api.Brokers.JwtToken;

public class JwtTokenBroker : IJwtTokenBroker
{
    private readonly IDateTimeBroker _dateTimeBroker;

    public JwtTokenBroker(IDateTimeBroker dateTimeBroker)
    {
        _dateTimeBroker = dateTimeBroker;
    }

    public string BuildToken(string issuer, string audience, string jwtSigningKey, int expiryDurationMinutes, User user)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSigningKey));
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email ?? throw new InvalidOperationException()),
                new Claim("role", user.Role ?? throw new InvalidOperationException()),
            }),
            Expires = _dateTimeBroker.TimeNow().DateTime.AddMinutes(expiryDurationMinutes),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public Guid ValidateToken(string issuer, string audience, string jwtSigningKey, string token)
    {
        var mySecret = Encoding.UTF8.GetBytes(jwtSigningKey);
        var mySecurityKey = new SymmetricSecurityKey(mySecret);
        var tokenHandler = new JwtSecurityTokenHandler();

        tokenHandler.ValidateToken(token,
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = mySecurityKey,
            }, out var validatedToken);

        var jwtToken = (JwtSecurityToken) validatedToken;

        return Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
    }
}