using System;
using System.Collections.Generic;

namespace ProjectSharp.WebApi.Features.ApplicationUser.Authenticate
{
    public static class AuthenticationRequestValidator
    {
        public static bool Validate(this AuthenticationRequest c)
        {
            var errorList = new Dictionary<string, List<string>>();

            if (errorList.Count > 0)
                throw new Exception();
            
            return true;
        }
        
        public static void UsernameIsNotNullOrWhiteSpace(string username, Dictionary<string, List<string>> errorList)
        {
            
        }
    }
}