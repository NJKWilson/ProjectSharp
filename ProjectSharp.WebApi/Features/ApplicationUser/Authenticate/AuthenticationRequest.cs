using System.Collections.Generic;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}