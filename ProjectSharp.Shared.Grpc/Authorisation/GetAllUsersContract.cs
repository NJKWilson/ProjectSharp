using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProjectSharp.Shared.Grpc.Authorisation
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public abstract class GetAllUsersContract
    {
        [ServiceContract]
        // ReSharper disable once ServiceContractWithoutOperations
        public interface IGetAllUsers
        {
            ValueTask<GetAllUsersResponse> GetAllUsersAsync();
        }

        [DataContract]
        public class GetAllUsersResponse
        {
            [DataMember(Order = 1)] public List<User> Users { get; set; }
            [DataMember(Order = 2)] public bool WasSuccessful { get; set; }
            [DataMember(Order = 3)] public List<string> Errors { get; set; }
        }
        
        public abstract class User
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }
    }
}