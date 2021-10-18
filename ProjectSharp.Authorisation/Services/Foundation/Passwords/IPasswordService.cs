namespace ProjectSharp.Authorisation.Services.Foundation.Passwords
{
    public interface IPasswordService
    {
        /// <summary>
        /// Hashes the password and returns the hash.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string HashPassword(string password);

        /// <summary>
        /// returns true if password matches hashed password
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool VerifyPassword(string passwordHash, string password);
    }
}