namespace ProjectSharp.Authorisation.Brokers.Password
{
    public interface IStringHashBroker
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}