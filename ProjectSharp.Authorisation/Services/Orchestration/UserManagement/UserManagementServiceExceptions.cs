using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Models.Users;
using ProjectSharp.Authorisation.Services.Foundation.Users.Exceptions;

namespace ProjectSharp.Authorisation.Services.Orchestration.UserManagement
{
    public static class UserManagementServiceExceptions
    {
        public delegate ValueTask VoidReturnFunction();
        public delegate ValueTask<string> StringReturnFunction();
        public delegate ValueTask<bool> BoolReturnFunction();
        public delegate ValueTask<User> UserReturnFunction();
        public delegate ValueTask<IEnumerable<User>> UserListReturnFunction();

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
        
        public static async ValueTask<string> TryCatch(StringReturnFunction stringReturnFunction)
        {
            try
            {
                return await stringReturnFunction();
            }
            catch (Exception exception)
            {
                throw new UserServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
        
        public static async ValueTask<bool> TryCatch(BoolReturnFunction boolReturnFunction)
        {
            try
            {
                return await boolReturnFunction();
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
        
        public static async ValueTask<IEnumerable<User>> TryCatch(UserListReturnFunction userListReturnFunction)
        {
            try
            {
                return await userListReturnFunction();
            }
            catch (Exception exception)
            {
                throw new UserServiceDependencyException(
                    $"User service dependency exception : {exception.Message}", exception);
            }
        }
    }
}