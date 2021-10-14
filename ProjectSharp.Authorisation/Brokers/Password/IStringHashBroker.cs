namespace ProjectSharp.Authorisation.Brokers.Password
{
    public interface IStringHashBroker
    {
        string HashString(string inputString);
        bool VerifyHashedString(string inputString, string inputStringHash);
    }
}