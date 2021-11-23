using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Gui.Features.Users.Delete;

public interface IDeleteUserFeature
{
    ValueTask<User> DeleteAsync(User user);
}