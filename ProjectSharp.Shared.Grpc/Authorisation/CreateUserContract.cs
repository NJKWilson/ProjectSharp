using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProjectSharp.Shared.Grpc.Authorisation
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CreateUserContract
    {
        [ServiceContract]
        // ReSharper disable once ServiceContractWithoutOperations
        public interface ICreateUser
        {
            ValueTask<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
        }

        [DataContract]
        public class CreateUserRequest
        {
            [DataMember(Order = 1)] public string Email { get; set; }
            [DataMember(Order = 2)] public string Password { get; set; }
        }

        [DataContract]
        public class CreateUserResponse
        {
            [DataMember(Order = 1)] public bool WasSuccessful { get; set; }
            [DataMember(Order = 2)] public List<string> Errors { get; set; }
        }
    }
}