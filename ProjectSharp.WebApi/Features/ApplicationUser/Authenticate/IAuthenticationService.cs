namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public interface IAuthenticationService
    {
        public void Authenticate(AuthenticationRequest authenticationRequest);
    }
}