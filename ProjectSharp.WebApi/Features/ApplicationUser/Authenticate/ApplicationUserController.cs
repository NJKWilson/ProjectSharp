using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<string> Get([FromBody] AuthenticationRequest authenticationRequest)
        {
            _authenticationService.Authenticate(authenticationRequest);
            return new string[] { "value1", "value2" };
        }
    }
}
