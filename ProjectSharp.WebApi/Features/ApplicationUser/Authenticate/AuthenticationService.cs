using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectSharp.WebApi.Brokers.BCryptBroker;
using ProjectSharp.WebApi.Brokers.JwtToken;
using ProjectSharp.WebApi.Brokers.MongoDb;
using ProjectSharp.WebApi.Common.AppSettings;
using ProjectSharp.WebApi.DbModel.ApplicationUser;
using ProjectSharp.WebUi.ProjectSharp.Shared.ApplicationUser.Authenticate;
using ProjectSharp.WebUi.ProjectSharp.Shared.Exceptions;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDataContext _dataContext;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(
            IDataContext dataContext, IPasswordService passwordService, 
            ITokenService tokenService, JwtSettings jwtSettings)
        {
            _dataContext = dataContext;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _jwtSettings = jwtSettings;
        }
        public async ValueTask<AuthenticationResponse> Authenticate(AuthenticationRequest authenticationRequest)
        {
            // Validate request model
            authenticationRequest.Validate();
            
            // Try to get user
            var user = await GetByEmail(authenticationRequest.Email);
            //todo exception
            if (user == null)
                throw new AuthenticationException("User does not exist.");
            
            // Check password is correct
            if (!_passwordService.VerifyHash(authenticationRequest.Password, user.PasswordSalt, user.PasswordHash))
                throw new AuthenticationException("Password incorrect.");
            
            // Generate jwt Token
            var token = _tokenService.BuildToken(_jwtSettings.Key, _jwtSettings.Issuer, user);
            
            // Create the response model
            var authenticationResponse = new AuthenticationResponse()
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
            
            return authenticationResponse;
        }

        private async Task<User> GetByEmail(string email)
        {
            var filter = Builders<User>.Filter.Where(user => user.Email == email);
            
            return await _dataContext.Users.Find(filter).FirstOrDefaultAsync();
        }
    }
}