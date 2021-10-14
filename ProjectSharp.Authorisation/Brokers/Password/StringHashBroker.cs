namespace ProjectSharp.Authorisation.Brokers.Password
{
    public class StringHashBroker : IStringHashBroker
    {
        private string GenerateSalt() => BCrypt.Net.BCrypt.GenerateSalt();

        public string HashString(string inputString)
            => BCrypt.Net.BCrypt.HashPassword(inputString, GenerateSalt());

        public bool VerifyHashedString(string inputString, string inputStringHash) =>
            BCrypt.Net.BCrypt.Verify(inputString, inputStringHash);
    }
}