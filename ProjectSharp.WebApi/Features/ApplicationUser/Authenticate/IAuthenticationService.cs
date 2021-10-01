using System.Threading.Tasks;
using ProjectSharp.WebApi.ApplicationUser.Authenticate;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public interface IAuthenticationService
    {
        ValueTask<AuthenticationResponse> Authenticate(AuthenticationRequest authenticationRequest);
    }
}