using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectSharp.Shared.ApplicationUser.Create;
using ProjectSharp.WebApi.Brokers.BCryptBroker;
using ProjectSharp.WebApi.Brokers.MongoDb;
using ProjectSharp.WebApi.DbModel.ApplicationUser;
using ProjectSharp.Shared.Exceptions;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Create
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUserCreateService : IApplicationUserCreateService
    {
        private readonly IDataContext _dataContext;
        private readonly IPasswordService _passwordService;

        public ApplicationUserCreateService(IDataContext dataContext, IPasswordService passwordService)
        {
            _dataContext = dataContext;
            _passwordService = passwordService;
        }
        
        /// <summary>
        /// Creates a New Application User
        /// </summary>
        /// <param name="applicationUserCreateRequest"></param>
        /// <param name="loggedInUser">Logged in User Creating the new user.</param>
        /// <returns></returns>
        public async ValueTask<ApplicationUserCreateResponse> 
            CreateAsync(ApplicationUserCreateRequest applicationUserCreateRequest, User loggedInUser)
        {
            // Validate request
            applicationUserCreateRequest.Validate();
            
            // Generate salt
            var passwordSalt = Guid.NewGuid().ToString();
            
            // Build new Application User
            var newApplicationUser = new User()
            {
                FirstName = applicationUserCreateRequest.FirstName,
                FamilyName = applicationUserCreateRequest.FamilyName,
                Email = applicationUserCreateRequest.Email,
                Role = UserRole.Disabled.ToString(),
                PasswordHash = _passwordService.HashPassword(applicationUserCreateRequest.Password, passwordSalt),
                PasswordSalt = passwordSalt,
                CreatedDate = DateTimeOffset.Now,
                CreatedBy = loggedInUser.Email
            };
            
            // Insert the new user
            await _dataContext.Users.InsertOneAsync(newApplicationUser);
            
            // Try and get the new user
            var response = await _dataContext.Users.Find(
                Builders<User>.Filter.Where(
                    user => user.Email == applicationUserCreateRequest.Email)).FirstOrDefaultAsync();
            
            // If user could not be found throw exception
            if (response == null)
                throw new DbOperationFailedException("Database Error User Not Created.");
            
            // Return the new user
            return new ApplicationUserCreateResponse() {Email = response.Email};
        }
    }
}