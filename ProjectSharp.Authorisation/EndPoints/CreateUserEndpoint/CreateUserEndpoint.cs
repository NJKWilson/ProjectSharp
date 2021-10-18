using System.Threading.Tasks;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Foundation.Passwords;
using ProjectSharp.Authorisation.Services.Foundation.Users;
using ProjectSharp.Shared.Grpc.Authorisation;

namespace ProjectSharp.Authorisation.EndPoints.CreateUserEndpoint
{
    public class CreateUserEndpoint : CreateUserContract.ICreateUser
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public CreateUserEndpoint(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        public ValueTask<CreateUserContract.CreateUserResponse>
            CreateUserAsync(CreateUserContract.CreateUserRequest request) =>
            CreateUserEndpointExceptions.TryCatch(
                async () =>
                {
                    request.ValidateFullRequest();

                    var newUser = new User
                    {
                        Email = request.Email,
                        PasswordHash = _passwordService.HashPassword(request.Password)
                    };

                    await _userService.CreateUserAsync(newUser);
                    
                    var response = new CreateUserContract.CreateUserResponse
                    {
                        WasSuccessful = true
                    };
                    return await new ValueTask<CreateUserContract.CreateUserResponse>(response);
                }
            );
    }
}