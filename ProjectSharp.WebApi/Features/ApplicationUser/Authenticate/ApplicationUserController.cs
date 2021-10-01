using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSharp.WebApi.ApplicationUser.Authenticate;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ApplicationUserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public ApplicationUserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        [HttpPost]
        [Route("[action]")]
        public async ValueTask<ActionResult<AuthenticationResponse>> 
            Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            return Ok(await _authenticationService.Authenticate(authenticationRequest));
        }
    }
}
