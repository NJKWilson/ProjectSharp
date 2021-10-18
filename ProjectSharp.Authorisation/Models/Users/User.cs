using MongoDB.Bson;

namespace ProjectSharp.Authorisation.Models.Users
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool Locked { get; set; }
        public string RefreshToken { get; set; }
    }
}