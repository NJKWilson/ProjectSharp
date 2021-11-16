using Microsoft.AspNetCore.Mvc;
using ProjectSharp.Api.Endpoints.Authentication.Login;

namespace ProjectSharp.Api.Endpoints.Authentication;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces("application/json")]
    public ActionResult<LoginResponse> Login()
    {
        var lr = new LoginResponse();
        return BadRequest(lr);
    }
}