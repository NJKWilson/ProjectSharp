using System;

namespace ProjectSharp.Authorisation.Services.Foundation.Tokens
{
    public static class TokenServiceExceptions
    {
        public delegate string ReturnsStringFunction();

        public static string TryCatch(ReturnsStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (Exception)
            {
                throw new Exception("nullAssignmentException");
            }
        }
    }
}