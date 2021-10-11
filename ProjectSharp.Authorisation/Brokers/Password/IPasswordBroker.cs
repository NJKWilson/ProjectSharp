namespace ProjectSharp.Authorisation.Brokers.Password
{
    public interface IPasswordBroker
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}