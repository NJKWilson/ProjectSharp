using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSharp.WebApi.DbModel.ApplicationUser;
using ProjectSharp.WebUi.ProjectSharp.Shared.ApplicationUser.Create;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Create
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserCreateService _applicationUserCreateService;

        public ApplicationUserController(IApplicationUserCreateService applicationUserCreateService)
        {
            _applicationUserCreateService = applicationUserCreateService;
        }
        
        [HttpPost]
        [Route("[action]")]
        public async ValueTask<ActionResult<ApplicationUserCreateResponse>> 
            Create([FromBody] ApplicationUserCreateRequest applicationUserCreateRequest)
        {
            return Ok(await _applicationUserCreateService.CreateAsync(applicationUserCreateRequest, new User()));
        }
    }
}
