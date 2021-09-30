using System.Threading.Tasks;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public interface IAuthenticationService
    {
        public ValueTask<AuthenticationResponse> Authenticate(AuthenticationRequest authenticationRequest);
    }
}