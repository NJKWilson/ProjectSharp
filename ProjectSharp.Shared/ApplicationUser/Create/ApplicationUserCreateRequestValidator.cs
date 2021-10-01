using System.Collections.Generic;
using ProjectSharp.Shared.Exceptions;
using ProjectSharp.Shared.Extenstion;

namespace ProjectSharp.Shared.ApplicationUser.Create
{
    public static class ApplicationUserCreateRequestValidator
    {
        /// <summary>
        /// Validates the request, throws Exception is errors are found.
        /// </summary>
        /// <param name="applicationUserCreateRequest"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public static bool Validate(this ApplicationUserCreateRequest applicationUserCreateRequest)
        {
            var errorList = new Dictionary<string, List<string>>();

            ValidateFirstName(applicationUserCreateRequest, errorList);
            ValidateFamilyName(applicationUserCreateRequest, errorList);
            ValidateUsername(applicationUserCreateRequest, errorList);
            ValidateEmail(applicationUserCreateRequest, errorList);
            ValidatePassword(applicationUserCreateRequest, errorList);


            if (errorList.Count > 0)
                throw new ValidationException(errorList);

            return true;
        }

        private static void ValidateFirstName(
            ApplicationUserCreateRequest applicationUserCreateRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(applicationUserCreateRequest.FirstName))
                errorList.AddOrUpdate(
                    nameof(applicationUserCreateRequest.FirstName),
                    $"{nameof(applicationUserCreateRequest.FirstName)} cannot be empty.");
        }
        private static void ValidateFamilyName(
            ApplicationUserCreateRequest applicationUserCreateRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(applicationUserCreateRequest.FamilyName))
                errorList.AddOrUpdate(
                    nameof(applicationUserCreateRequest.FamilyName),
                    $"{nameof(applicationUserCreateRequest.FamilyName)} cannot be empty.");
        }
        private static void ValidateUsername(
            ApplicationUserCreateRequest applicationUserCreateRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(applicationUserCreateRequest.Username))
                errorList.AddOrUpdate(
                    nameof(applicationUserCreateRequest.Username),
                    $"{nameof(applicationUserCreateRequest.Username)} cannot be empty.");
        }
        private static void ValidateEmail(
            ApplicationUserCreateRequest applicationUserCreateRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(applicationUserCreateRequest.Email))
                errorList.AddOrUpdate(
                    nameof(applicationUserCreateRequest.Email),
                    $"{nameof(applicationUserCreateRequest.Email)} cannot be empty.");
        }
        private static void ValidatePassword(
            ApplicationUserCreateRequest applicationUserCreateRequest, Dictionary<string, List<string>> errorList)
        {
            if (string.IsNullOrWhiteSpace(applicationUserCreateRequest.Password))
                errorList.AddOrUpdate(
                    nameof(applicationUserCreateRequest.Password),
                    $"{nameof(applicationUserCreateRequest.Password)} cannot be empty.");
        }
        
    }
}