using System.Threading.Tasks;
using ProjectSharp.Authorisation.Services;
using ProjectSharp.Shared.Grpc;
using Xunit;

namespace ProjectSharp.Authorisation.Tests.Services
{
    public class AuthorisationServiceTests
    {
        [Fact]
        public async Task AuthorisationService_Throws_NotImplemented()
        {
            //given
            var authorisationService = new AuthorisationService();
            var authoriseRequestModel = new AuthorisationContracts.AuthoriseRequest
            {
                Username = "admin@psharp.com",
                Password = "admin"
            };
            
            //when

            //should
            await Assert.ThrowsAsync<System.NotImplementedException>(
                async ()  => await authorisationService.AuthoriseAsync(authoriseRequestModel));
        }
    }
}