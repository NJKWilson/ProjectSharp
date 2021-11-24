using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Users.Delete;

public interface IDeleteUserFeature
{
    ValueTask<User> DeleteAsync(User user);
}