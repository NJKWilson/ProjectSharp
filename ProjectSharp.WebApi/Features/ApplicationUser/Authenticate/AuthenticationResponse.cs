using ProjectSharp.WebApi.DbModel.ApplicationUser;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public AuthenticationResponse(IUser user, string token)
        {
            Id = user.Id.ToString();
            Username = user.Username;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}