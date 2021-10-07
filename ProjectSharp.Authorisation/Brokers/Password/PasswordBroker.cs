namespace ProjectSharp.Authorisation.Brokers.Password
{
    public class PasswordBroker : IPasswordBroker
    {
        public string HashPassword(string password)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            throw new System.NotImplementedException();
        }
    }
}