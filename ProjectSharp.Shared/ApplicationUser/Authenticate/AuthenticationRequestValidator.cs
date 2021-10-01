using System.Collections.Generic;
using ProjectSharp.WebApi.Exceptions;
using ProjectSharp.WebApi.Extenstion;

namespace ProjectSharp.WebApi.ApplicationUser.Authenticate
{
    public static class AuthenticationRequestValidator
    {
        /// <summary>
        /// Validates the request, throws Exception is errors are found.
        /// </summary>
        /// <param name="authenticationRequest"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public static bool Validate(this AuthenticationRequest authenticationRequest)
        {
            var errorList = new Dictionary<string, List<string>>();

            EmailIsNotNullOrWhiteSpace(authenticationRequest, errorList);
            PasswordIsNotNullOrWhiteSpace(authenticationRequest, errorList);

            if (errorList.Count > 0)
                throw new ValidationException(errorList);

            return true;
        }

        private static void EmailIsNotNullOrWhiteSpace(
            AuthenticationRequest authenticationRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.Email))
                errorList.AddOrUpdate(
                    nameof(authenticationRequest.Email),
                    $"{nameof(authenticationRequest.Email)} cannot be empty.");
        }

        private static void PasswordIsNotNullOrWhiteSpace(
            AuthenticationRequest authenticationRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.Password))
                errorList.AddOrUpdate(
                    nameof(authenticationRequest.Password),
                    $"{nameof(authenticationRequest.Password)} cannot be empty.");
        }
    }
}