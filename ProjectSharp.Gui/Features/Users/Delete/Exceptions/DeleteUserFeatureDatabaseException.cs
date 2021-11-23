namespace ProjectSharp.Gui.Features.Users.Delete.Exceptions;

public class DeleteUserFeatureDatabaseException : Exception
{
    public DeleteUserFeatureDatabaseException(string message, Exception exception)
        :base(message, exception) { }
}