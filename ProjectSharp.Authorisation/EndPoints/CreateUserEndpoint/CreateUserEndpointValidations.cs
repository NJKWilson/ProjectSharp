using System.Collections.Generic;
using ProjectSharp.Authorisation.EndPoints.CreateUserEndpoint.Exceptions;
using ProjectSharp.Shared.Grpc.Authorisation;

namespace ProjectSharp.Authorisation.EndPoints.CreateUserEndpoint
{
    public static class CreateUserEndpointValidations
    {
        public static void ValidateFullRequest(this CreateUserContract.CreateUserRequest request)
        {
            var errors = new List<string>();
            
            if (request is null)
            {
                errors.Add("Request is null");
            }

            if (string.IsNullOrWhiteSpace(request?.Email))
            {
                errors.Add("Request 'Email' is empty");
            }
            
            if (string.IsNullOrWhiteSpace(request?.Password))
            {
                errors.Add("Request 'Password' is empty");
            }

            if (errors.Count > 0)
            {
                throw new CreateUserEndpointValidationException("Validation Errors", errors);
            }
        }
    }
}