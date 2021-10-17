using ProjectSharp.Authorisation.Services.Foundation.Passwords.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.Passwords
{
    public static class PasswordServiceValidations
    {
        public static void ValidateHashPasswordInput(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new PasswordServiceValidationException("Password is empty");
            }
        }
        
        public static void ValidateVerifyPasswordInput(string passwordHash ,string password)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new PasswordServiceValidationException("PasswordHash is empty");
            }
            
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new PasswordServiceValidationException("Password is empty");
            }
        }
    }
}