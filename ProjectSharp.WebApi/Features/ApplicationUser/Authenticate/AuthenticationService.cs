namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public class AuthenticationService : IAuthenticationService
    {
        public void Authenticate(AuthenticationRequest authenticationRequest)
        {
            authenticationRequest.Validate();
        }
    }
}