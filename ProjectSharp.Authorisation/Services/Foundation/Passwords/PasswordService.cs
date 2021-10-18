using ProjectSharp.Authorisation.Brokers.Password;

namespace ProjectSharp.Authorisation.Services.Foundation.Passwords
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordBroker _passwordBroker;

        public PasswordService(IPasswordBroker passwordBroker)
        {
            _passwordBroker = passwordBroker;
        }
        
        public string HashPassword(string password) =>
            PasswordServiceExceptions.TryCatch(
                () =>
                {
                    PasswordServiceValidations.ValidateHashPasswordInput(password);
                    return _passwordBroker.HashPassword(password);
                }

            );

        public bool VerifyPassword(string passwordHash, string password) =>
            PasswordServiceExceptions.TryCatch(
                () =>
                {
                    PasswordServiceValidations.ValidateVerifyPasswordInput(passwordHash, password);
                    return _passwordBroker.VerifyPassword(passwordHash, password);
                }
            );
    }
}