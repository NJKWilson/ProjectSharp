namespace ProjectSharp.Gui.Features.Users.Delete.Exceptions;

public class DeleteUserFeatureUserDoesNotExistException : Exception
{
    public DeleteUserFeatureUserDoesNotExistException()
        : base("User does not exist.") { }
}