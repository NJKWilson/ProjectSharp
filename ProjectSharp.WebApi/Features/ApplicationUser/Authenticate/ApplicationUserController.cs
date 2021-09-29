using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ApplicationUserController : ControllerBase
    {
        // GET: api/ApplicationUser
        [HttpPost]
        public IEnumerable<string> Get(AuthenticationRequest authenticationRequest)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
