using System;
using ProjectSharp.Authorisation.Services.Foundation.Passwords.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.Passwords
{
    public static class PasswordServiceExceptions
    {
        public delegate string StringReturnFunction();
        public delegate bool BoolReturnFunction();

        public static string TryCatch(StringReturnFunction stringReturnFunction)
        {
            try
            {
                return stringReturnFunction();
            }
            catch (Exception exception)
            {
                throw new PasswordServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
        
        public static bool TryCatch(BoolReturnFunction boolReturnFunction)
        {
            try
            {
                return boolReturnFunction();
            }
            catch (Exception exception)
            {
                throw new PasswordServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
    }
}