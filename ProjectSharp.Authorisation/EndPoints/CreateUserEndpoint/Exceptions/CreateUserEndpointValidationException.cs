using System;
using System.Collections.Generic;

namespace ProjectSharp.Authorisation.EndPoints.CreateUserEndpoint.Exceptions
{
    public class CreateUserEndpointValidationException : Exception
    {
        public readonly List<string> Errors;
        public CreateUserEndpointValidationException(string message, List<string> errors) 
            : base(message)
        {
            Errors = errors;
        }
    }
}