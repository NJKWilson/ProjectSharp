namespace ProjectSharp.WebApi.Brokers.BCryptBroker
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword($"{password}{salt}");
        }

        public bool VerifyHash(string password, string salt, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify($"{password}{salt}", passwordHash);
        }
    }
}