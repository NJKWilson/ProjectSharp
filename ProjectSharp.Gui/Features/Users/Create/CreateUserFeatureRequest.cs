using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Gui.Features.Users.Create;

public class CreateUserFeatureRequest
{
    public string Email { get; }
    public string Password { get; }
    public User CreatingUser { get; }

    public CreateUserFeatureRequest(string email, string password, User creatingUser)
    {
        Email = email;
        Password = password;
        CreatingUser = creatingUser;
    }
}