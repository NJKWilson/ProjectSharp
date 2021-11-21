using Microsoft.AspNetCore.Mvc;
using ProjectSharp.Api.Endpoints.Authentication.Login;
using ProjectSharp.Api.Endpoints.UserManagement.Create;
using ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;
using ProjectSharp.Api.Endpoints.UserManagement.Delete;
using ProjectSharp.Api.Endpoints.UserManagement.GetById;
using ProjectSharp.Api.Endpoints.UserManagement.Update;
using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Api.Endpoints.UserManagement;

[ApiController]
[Route("[controller]")]
public class UserManagementController : ControllerBase
{
    private readonly ILogger<UserManagementController> _logger;
    private readonly CreateUserHandler _createUserHandler;

    public UserManagementController(
        ILogger<UserManagementController> logger,
        CreateUserHandler createUserHandler)
    {
        _logger = logger;
        _createUserHandler = createUserHandler;
    }
    
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async ValueTask<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
    {
        var user = (User?)HttpContext.Items["User"];
        if (user == null)
            return Problem(title: "Unauthorized", statusCode: 401);

        try
        {
            return Ok(await _createUserHandler.CreateUser(createUserRequest, user));
        }
        catch (CreateUserHandlerUserAlreadyExistsException e)
        {
            return Problem(title:e.Message, statusCode:400);
        }
        catch (Exception)
        {
            return Problem(title:"Unhandled Exception", statusCode:500);
        }
    }
    
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces("application/json")]
    public ActionResult<DeleteUserResponse> Delete([FromBody] DeleteUserRequest createUserRequest)
    {
        var lr = new LoginResponse();
        return BadRequest(lr);
    }
    
    [HttpGet]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces("application/json")]
    public ActionResult<GetByIdUserResponse> GetById([FromBody] GetByIdUserRequest createUserRequest)
    {
        var lr = new LoginResponse();
        return BadRequest(lr);
    }
    
    [HttpPut]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Produces("application/json")]
    public ActionResult<UpdateUserResponse> Update([FromBody] UpdateUserRequest createUserRequest)
    {
        var lr = new LoginResponse();
        return BadRequest(lr);
    }
}