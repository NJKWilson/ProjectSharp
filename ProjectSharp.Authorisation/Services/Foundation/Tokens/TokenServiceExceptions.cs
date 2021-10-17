using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Tokens
{
    public static class TokenServiceExceptions
    {
        public delegate string ReturningTokenFunction();

        public static string TryCatch(ReturningTokenFunction returningTokenFunction)
        {
            try
            {
                return returningTokenFunction();
            }
            catch (Exception nullAssignmentException)
            {
                throw new Exception("nullAssignmentException");
            }
        }
    }
}