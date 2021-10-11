namespace ProjectSharp.Authorisation.Brokers.Password
{
    public class PasswordBroker : IPasswordBroker
    {
        public (string passwordHash, string salt) HashPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return (passwordHash, salt);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}