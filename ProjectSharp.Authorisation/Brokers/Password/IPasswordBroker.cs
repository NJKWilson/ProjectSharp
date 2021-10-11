namespace ProjectSharp.Authorisation.Brokers.Password
{
    public interface IPasswordBroker
    {
        (string passwordHash, string salt) HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}