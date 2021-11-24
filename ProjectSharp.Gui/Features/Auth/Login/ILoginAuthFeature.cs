using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Auth.Login;

public interface ILoginAuthFeature
{
    ValueTask<User> Login(string username, string password);
}