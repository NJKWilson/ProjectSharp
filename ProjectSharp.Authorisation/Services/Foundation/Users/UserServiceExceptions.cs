using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Foundation.Users.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.Users
{
    public static class UserServiceExceptions
    {
        public delegate ValueTask VoidReturnFunction();
        public delegate ValueTask<User> UserReturnFunction();
        public delegate ValueTask<IEnumerable<User>> UserEnumerableReturnFunction();

        public static async ValueTask TryCatch(VoidReturnFunction voidReturnFunction)
        {
            try
            {
                await voidReturnFunction();
            }
            catch (Exception exception)
            {
                throw new UserServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
        
        public static async ValueTask<User> TryCatch(UserReturnFunction userReturnFunction)
        {
            try
            {
                return await userReturnFunction();
            }
            catch (Exception exception)
            {
                throw new UserServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
        
        public static async ValueTask<IEnumerable<User>> TryCatch(UserEnumerableReturnFunction userEnumerableReturnFunction)
        {
            try
            {
                return await userEnumerableReturnFunction();
            }
            catch (Exception exception)
            {
                throw new UserServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
    }
}