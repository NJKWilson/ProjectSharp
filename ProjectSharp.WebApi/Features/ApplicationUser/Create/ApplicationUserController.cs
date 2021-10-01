using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSharp.Shared.ApplicationUser.Create;
using ProjectSharp.WebApi.DbModel.ApplicationUser;

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
