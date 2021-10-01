using System.Threading.Tasks;
using ProjectSharp.Shared.ApplicationUser.Create;
using ProjectSharp.WebApi.DbModel.ApplicationUser;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Create
{
    public interface IApplicationUserCreateService
    {
        ValueTask<ApplicationUserCreateResponse> 
            CreateAsync(ApplicationUserCreateRequest applicationUserCreateRequest, string user);
    }
}