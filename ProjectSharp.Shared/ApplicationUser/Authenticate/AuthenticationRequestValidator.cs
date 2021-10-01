using System.Collections.Generic;
using ProjectSharp.WebUi.ProjectSharp.Shared.Exceptions;
using ProjectSharp.WebUi.ProjectSharp.Shared.Extenstion;

namespace ProjectSharp.WebUi.ProjectSharp.Shared.ApplicationUser.Authenticate
{
    public static class AuthenticationRequestValidator
    {
        /// <summary>
        /// Validates the request, throws Exception is errors are found.
        /// </summary>
        /// <param name="authenticationRequest"></param>
        /// <returns></returns>
        /// <exception cref="RequestValidationException"></exception>
        public static bool Validate(this AuthenticationRequest authenticationRequest)
        {
            var errorList = new Dictionary<string, List<string>>();

            UsernameIsNotNullOrWhiteSpace(authenticationRequest, errorList);
            PasswordIsNotNullOrWhiteSpace(authenticationRequest, errorList);

            if (errorList.Count > 0)
                throw new ValidationException(errorList);

            return true;
        }

        private static void UsernameIsNotNullOrWhiteSpace(
            AuthenticationRequest authenticationRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.Username))
                errorList.AddOrUpdate(
                    nameof(authenticationRequest.Username),
                    $"{nameof(authenticationRequest.Username)} cannot be empty.");
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