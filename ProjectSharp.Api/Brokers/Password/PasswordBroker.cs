namespace ProjectSharp.Api.Brokers.Password;

public class PasswordBroker : IPasswordBroker
{
    public string HashPassword(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();

        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}