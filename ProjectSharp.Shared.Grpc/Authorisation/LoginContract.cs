using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProjectSharp.Shared.Grpc.Authorisation
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class LoginUserContract
    {
        [ServiceContract]
        // ReSharper disable once ServiceContractWithoutOperations
        public interface ICreateUser
        {
            ValueTask<LoginResponse> LoginAsync(LoginRequest request);
        }

        [DataContract]
        public class LoginRequest
        {
            [DataMember(Order = 1)] public string Email { get; set; }
            [DataMember(Order = 2)] public string Password { get; set; }
        }

        [DataContract]
        public class LoginResponse
        {
            [DataMember(Order = 1)] public string JwtToken { get; set; }
            [DataMember(Order = 2)] public bool WasSuccessful { get; set; }
            [DataMember(Order = 3)] public List<string> Errors { get; set; }
        }
    }
}