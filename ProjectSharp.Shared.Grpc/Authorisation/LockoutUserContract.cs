using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProjectSharp.Shared.Grpc.Authorisation
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class LockoutUserContract
    {
        [ServiceContract]
        // ReSharper disable once ServiceContractWithoutOperations
        public interface ICreateUser
        {
            ValueTask<LockoutUserResponse> LockoutUserAsync(LockoutUserRequest request);
        }

        [DataContract]
        public class LockoutUserRequest
        {
            [DataMember(Order = 1)] public string UserId { get; set; }
        }

        [DataContract]
        public class LockoutUserResponse
        {
            [DataMember(Order = 1)] public bool WasSuccessful { get; set; }
            [DataMember(Order = 2)] public List<string> Errors { get; set; }
        }
    }
}