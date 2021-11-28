namespace ProjectSharp.Gui.Features.Users.Delete.Exceptions;

public class DeleteUserFeatureBadRequestException : Exception
{
    public DeleteUserFeatureBadRequestException()
        : base("Bad request exception id is empty.")
    {
    }
}