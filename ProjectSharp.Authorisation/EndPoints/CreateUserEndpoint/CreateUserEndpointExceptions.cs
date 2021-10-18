using System;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.EndPoints.CreateUserEndpoint.Exceptions;
using ProjectSharp.Shared.Grpc.Authorisation;

namespace ProjectSharp.Authorisation.EndPoints.CreateUserEndpoint
{
    public static class CreateUserEndpointExceptions
    {
        public delegate ValueTask<CreateUserContract.CreateUserResponse> ResponseFunction();

        public static async ValueTask<CreateUserContract.CreateUserResponse> TryCatch(
            ResponseFunction responseFunction)
        {
            try
            {
                return await responseFunction();
            }
            catch (CreateUserEndpointValidationException e)
            {
                Console.WriteLine($"{nameof(e)} {e.Message}");
                
                var response = new CreateUserContract.CreateUserResponse
                {
                    WasSuccessful = false,
                    Errors = e.Errors
                };

                return await new ValueTask<CreateUserContract.CreateUserResponse>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{nameof(e)} {e.Message}");
                
                var response = new CreateUserContract.CreateUserResponse
                {
                    WasSuccessful = false,
                };
                
                response.Errors.Add($"{nameof(e)} {e.Message}");

                return await new ValueTask<CreateUserContract.CreateUserResponse>(response);
            }
        }
    }
}