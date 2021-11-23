namespace ProjectSharp.Gui.Core.Brokers.Password;

public interface IPasswordBroker
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
    bool VerifyPassword(string password, string passwordHash);
}