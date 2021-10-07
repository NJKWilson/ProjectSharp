using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProjectSharp.Shared.Grpc
{
    public class AuthorisationContracts
    {
        [ServiceContract(Name = "ProjectSharp.Authorisation")]
        public interface IAuthorise
        {
            ValueTask<AuthoriseResponse> AuthoriseAsync(AuthoriseRequest request);
        }

        [DataContract]
        public class AuthoriseRequest
        {
            [DataMember(Order = 1)]
            public string Username { get; set; }

            [DataMember(Order = 2)]
            public string Password { get; set; }
        }

        [DataContract]
        public class AuthoriseResponse
        {
            [DataMember(Order = 1)]
            public string Jwt { get; set; }
        }
    }
}