using System.Threading.Tasks;
using ProjectSharp.WebApi.DbModel.ApplicationUser;
using ProjectSharp.WebUi.ProjectSharp.Shared.ApplicationUser.Create;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Create
{
    public interface IApplicationUserCreateService
    {
        ValueTask<ApplicationUserCreateResponse> 
            CreateAsync(ApplicationUserCreateRequest applicationUserCreateRequest, User user);
    }
}