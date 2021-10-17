using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Brokers.Token
{
    public class TokenBroker : ITokenBroker
    {
        public string BuildToken(
            string issuer, string audience, string jwtSigningKey, int expiryDurationMinutes,
            ApplicationUserModel user)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSigningKey));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("email", user.Email),
                    new Claim("role", user.Role),
                }),
                Expires = DateTime.UtcNow.AddMinutes(expiryDurationMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string ValidateToken(
            string issuer, string audience, string jwtSigningKey, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(jwtSigningKey);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = mySecurityKey,
                }, out var validatedToken);

            var jwtToken = (JwtSecurityToken) validatedToken;

            return jwtToken.Claims.First(x => x.Type == "id").Value;
        }
    }
}