using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSharp.WebUi.ProjectSharp.Shared.ApplicationUser.Authenticate;

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
        // GET: api/ApplicationUser
        [HttpPost]
        public async ValueTask<ActionResult<AuthenticationResponse>> 
            Get([FromBody] AuthenticationRequest authenticationRequest)
        {
            return Ok(await _authenticationService.Authenticate(authenticationRequest));
        }
    }
}
