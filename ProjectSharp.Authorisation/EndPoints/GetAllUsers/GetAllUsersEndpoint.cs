using System.Threading.Tasks;
using ProjectSharp.Authorisation.Services.Foundation.Users;
using ProjectSharp.Shared.Grpc.Authorisation;

namespace ProjectSharp.Authorisation.EndPoints.GetAllUsers
{
    public class GetAllUsersEndpoint : GetAllUsersContract.IGetAllUsers
    {
        private readonly IUserService _userService;

        public GetAllUsersEndpoint(IUserService userService)
        {
            _userService = userService;
        }
        
        public ValueTask<GetAllUsersContract.GetAllUsersResponse> GetAllUsersAsync() =>
            GetAllUsersExceptions.TryCatch(
                async () =>
                {
                    await _userService.GetAllUsersAsync();
                    
                    var response = new GetAllUsersContract.GetAllUsersResponse
                    {
                        WasSuccessful = true
                    };
                    return await new ValueTask<GetAllUsersContract.GetAllUsersResponse>(response);
                }
            );
    }
}