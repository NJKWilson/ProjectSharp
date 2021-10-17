using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Services.Coordination
{
    public interface ISecurityService
    {
        string BuildToken(string audience, User user);
        string VerifyToken(string audience, string token);
        void ChangeJwtSigningKey();
        string HashPassword(string password);
        bool VerifyPassword(string passwordHash, string password);
    }
}