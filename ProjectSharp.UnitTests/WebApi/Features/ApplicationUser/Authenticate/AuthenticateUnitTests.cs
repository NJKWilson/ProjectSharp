using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectSharp.WebApi.Common.Exceptions;
using ProjectSharp.WebApi.Common.Extensions;
using ProjectSharp.WebApi.Features.ApplicationUser.Authenticate;
using Xunit;

namespace ProjectSharp.UnitTests.WebApi.Features.ApplicationUser.Authenticate
{
    public class Authenticate
    {
        [Fact]
        public void ThrowsValidationException()
        {
            // Given
            var authenticationService = new AuthenticationService();
            var authenticationRequest = new AuthenticationRequest() {Username = "", Password = ""};
            var errorList = new Dictionary<string, List<string>>();
            errorList.AddOrUpdate("Username", "Username cannot be empty.");
            errorList.AddOrUpdate("Username", "Username must be longer than four characters.");
            var errorMessage = JsonConvert.SerializeObject(errorList);
            
            
            var exception = Assert.Throws<RequestValidationException>(() => authenticationService.Authenticate(authenticationRequest));
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}