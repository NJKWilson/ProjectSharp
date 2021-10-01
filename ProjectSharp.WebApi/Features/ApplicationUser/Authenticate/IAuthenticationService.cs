using System.Threading.Tasks;
using ProjectSharp.WebUi.ProjectSharp.Shared.ApplicationUser.Authenticate;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public interface IAuthenticationService
    {
        public ValueTask<AuthenticationResponse> Authenticate(AuthenticationRequest authenticationRequest);
    }
}