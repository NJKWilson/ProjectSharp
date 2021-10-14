using System;
using System.Collections.Generic;
using MongoDB.Bson;
using ProjectSharp.Authorisation.Entities.User;
using ProjectSharp.Authorisation.Entities.User.Exceptions;

namespace ProjectSharp.Authorisation.Services.Foundation.UserService
{
    public partial class UserService
    {
        private void ValidateUser(IUser user)
        {
            ValidateUserIsNotNull(user);

            Validate(
                (Rule: IsInvalidX(user.Id), Parameter: nameof(user.Id)),
                (Rule: IsInvalidX(user.FirstName), Parameter: nameof(user.FirstName)),
                (Rule: IsInvalidX(user.FamilyName), Parameter: nameof(user.FamilyName)),
                (Rule: IsInvalidX(user.Email), Parameter: nameof(user.Email)),
                (Rule: IsInvalidX(user.Role), Parameter: nameof(user.Role)),
                (Rule: IsInvalidX(user.CreatedBy), Parameter: nameof(user.CreatedBy)),
                (Rule: IsInvalidX(user.UpdatedBy), Parameter: nameof(user.UpdatedBy)),
                (Rule: IsInvalidX(user.CreatedDate), Parameter: nameof(user.CreatedDate)),
                (Rule: IsInvalidX(user.UpdatedDate), Parameter: nameof(user.UpdatedDate))
            );
        }

        private static void ValidateUserIsNotNull(IUser user)
        {
            if (user is null)
            {
                throw new NullUserException();
            }
        }

        private static dynamic IsInvalidX(ObjectId id) => new
        {
            Condition = id == ObjectId.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalidX(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalidX(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidStudentException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (!rule.Condition) continue;

                if (invalidStudentException.Data.Contains(parameter))
                {
                    (invalidStudentException.Data[parameter] as List<string>)?.Add(rule.Message);
                }
                else
                {
                    invalidStudentException.Data.Add(parameter, new List<string> {rule.Message});
                }
            }

            if (invalidStudentException.Data.Count > 0)
            {
                throw invalidStudentException;
            }
        }
    }
}