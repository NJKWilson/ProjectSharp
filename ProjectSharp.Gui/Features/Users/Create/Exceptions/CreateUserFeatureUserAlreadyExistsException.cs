using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Gui.Features.Users.Create.Exceptions;

public class CreateUserFeatureUserAlreadyExistsException : Exception
{
    public CreateUserFeatureUserAlreadyExistsException(User user)
        : base($"User with email '{user.Email}' already exists.") { }
}