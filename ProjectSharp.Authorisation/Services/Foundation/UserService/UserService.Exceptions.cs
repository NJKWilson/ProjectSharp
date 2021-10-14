using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Entities.User;
using ProjectSharp.Authorisation.Entities.User.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.UserService
{
    public partial class UserService
    {
        private delegate ValueTask UserFunction();

        private delegate ValueTask<User> ReturningUserFunction();

        private delegate IEnumerable<User> ReturningQueryableUserFunction();

        private async ValueTask TryCatch(UserFunction userFunction)
        {
            try
            {
                await userFunction();
            }
            catch (NullUserException nullUserException)
            {
                throw CreateAndLogValidationException(nullUserException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return await returningUserFunction();
            }
            catch (NullUserException nullUserException)
            {
                throw CreateAndLogValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateAndLogValidationException(invalidUserException);
            }
            // catch (NotFoundUserException nullUserException)
            // {
            //     throw CreateAndLogValidationException(nullUserException);
            // }
            // catch (DuplicateKeyException duplicateKeyException)
            // {
            //     var alreadyExistsUserException =
            //         new AlreadyExistsUserException(duplicateKeyException);
            //
            //     throw CreateAndLogValidationException(alreadyExistsUserException);
            // }
            // catch (SqlException sqlException)
            // {
            //     throw CreateAndLogCriticalDependencyException(sqlException);
            // }
            // catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            // {
            //     var lockedUserException = new LockedUserException(dbUpdateConcurrencyException);
            //
            //     throw CreateAndLogDependencyException(lockedUserException);
            // }
            // catch (DbUpdateException dbUpdateException)
            // {
            //     throw CreateAndLogDependencyException(dbUpdateException);
            // }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private IEnumerable<User> TryCatch(ReturningQueryableUserFunction returningQueryableUserFunction)
        {
            try
            {
                return returningQueryableUserFunction();
            }
            // catch (SqlException sqlException)
            // {
            //     throw CreateAndLogCriticalDependencyException(sqlException);
            // }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private UserServiceException CreateAndLogServiceException(Exception exception)
        {
            var userServiceException = new UserServiceException(exception);
            _loggingBroker.LogError(userServiceException);

            return userServiceException;
        }

        private UserDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var userDependencyException = new UserDependencyException(exception);
            _loggingBroker.LogError(userDependencyException);

            return userDependencyException;
        }

        private UserDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var userDependencyException = new UserDependencyException(exception);
            _loggingBroker.LogCritical(userDependencyException);

            return userDependencyException;
        }

        private Exception CreateAndLogValidationException(Exception exception)
        {
            var userValidationException = new UserValidationException(exception);
            _loggingBroker.LogError(userValidationException);

            return userValidationException;
        }
    }
}