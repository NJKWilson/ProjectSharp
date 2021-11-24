using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Users.Create;

public interface ICreateUserFeature
{
    ValueTask<User> InsertAsync(string email, string password, User creatingUser);
}