using System.Threading.Tasks;
using ProjectSharp.Shared.Grpc;

namespace ProjectSharp.Authorisation.Services
{
    public class AuthorisationService : AuthorisationContracts.IAuthorise
    {
        public async ValueTask<AuthorisationContracts.AuthoriseResponse> 
            AuthoriseAsync(AuthorisationContracts.AuthoriseRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}