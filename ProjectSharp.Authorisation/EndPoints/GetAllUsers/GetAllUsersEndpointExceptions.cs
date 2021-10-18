using System;
using System.Threading.Tasks;
using ProjectSharp.Shared.Grpc.Authorisation;

namespace ProjectSharp.Authorisation.EndPoints.GetAllUsers
{
    public static class GetAllUsersExceptions
    {
        public delegate ValueTask<GetAllUsersContract.GetAllUsersResponse> ResponseFunction();

        public static async ValueTask<GetAllUsersContract.GetAllUsersResponse> TryCatch(
            ResponseFunction responseFunction)
        {
            try
            {
                return await responseFunction();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{nameof(e)} {e.Message}");
                
                var response = new GetAllUsersContract.GetAllUsersResponse
                {
                    WasSuccessful = false,
                };
                
                response.Errors.Add($"{nameof(e)} {e.Message}");

                return await new ValueTask<GetAllUsersContract.GetAllUsersResponse>(response);
            }
        }
    }
}