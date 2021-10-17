using System;

namespace ProjectSharp.Authorisation.Services.Foundation.TokenService
{
    public class TokenServiceExceptions
    {
        protected delegate string ReturningTokenFunction();

        protected string TryCatch(ReturningTokenFunction returningTokenFunction)
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