using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectSharp.WebApi.Brokers.BCryptBroker;
using ProjectSharp.WebApi.Brokers.JwtToken;
using ProjectSharp.WebApi.Brokers.MongoDb;
using ProjectSharp.WebApi.Common.AppSettings;
using ProjectSharp.WebApi.Common.Exceptions;
using ProjectSharp.WebApi.DbModel.ApplicationUser;

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
            authenticationRequest.Validate();

            var user = await GetByUsername(authenticationRequest.Username);
            //todo exception
            if (user == null)
                throw new ApplicationUserCredentialsException("User does not exist.");
            
            //todo exception
            if (!_passwordService.VerifyHash(authenticationRequest.Password, user.PasswordSalt, user.PasswordHash))
                throw new ApplicationUserCredentialsException("Password incorrect.");

            var token = _tokenService.BuildToken(_jwtSettings.Key, _jwtSettings.Issuer, user);
            
            
            return new AuthenticationResponse(user, token);
        }

        private async Task<User> GetByUsername(string username)
        {
            var filter = Builders<User>.Filter.Where(user => user.Username == username);
            
            return await _dataContext.Users.Find(filter).FirstOrDefaultAsync();
        }
    }
}