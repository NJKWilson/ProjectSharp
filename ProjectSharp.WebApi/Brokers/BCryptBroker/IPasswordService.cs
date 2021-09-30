namespace ProjectSharp.WebApi.Brokers.BCryptBroker
{
    public interface IPasswordService
    {
        string HashPassword(string password, string salt);
        bool VerifyHash(string password, string salt, string passwordHash);
    }
}