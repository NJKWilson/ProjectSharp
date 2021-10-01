using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectSharp.WebApi.ApplicationUser.Authenticate;
using ProjectSharp.WebApi.ApplicationUser.Create;
using ProjectSharp.WebApi.Exceptions;
using ProjectSharp.WebApi.Extenstion;
using Xunit;

namespace ProjectSharp.UnitTests.Shared.ApplicationUser
{
    public class ApplicationUserUnitTests
    {
        [Fact]
        public void AuthenticationValidationException()
        {
            // Given
            var authenticationRequest = new AuthenticationRequest();
            
            var errorList = new Dictionary<string, List<string>>();
            errorList.AddOrUpdate("Username", "Username cannot be empty.");
            errorList.AddOrUpdate("Password", "Password cannot be empty.");

            var exception = Assert.Throws<ValidationException>(() => authenticationRequest.Validate());
            
            Assert.Equal(JsonConvert.SerializeObject(errorList), JsonConvert.SerializeObject(exception.ErrorList));
        }
        
        [Fact]
        public void ApplicationUserCreateValidationException()
        {
            // Given
            var applicationUserCreateRequest = new ApplicationUserCreateRequest();
            
            var errorList = new Dictionary<string, List<string>>();
            errorList.AddOrUpdate("FirstName", "FirstName cannot be empty.");
            errorList.AddOrUpdate("FamilyName", "FamilyName cannot be empty.");
            errorList.AddOrUpdate("Username", "Username cannot be empty.");
            errorList.AddOrUpdate("Email", "Email cannot be empty.");
            errorList.AddOrUpdate("Password", "Password cannot be empty.");

            var exception = Assert.Throws<ValidationException>(() => applicationUserCreateRequest.Validate());
            
            Assert.Equal(errorList, exception.ErrorList);
        }
    }
}