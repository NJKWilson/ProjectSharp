using ProjectSharp.DataAccess.Entities;
using User = ProjectSharp.Gui.Database.Entities.User;

namespace ProjectSharp.Gui.Features.Users.Delete;

public interface IDeleteUserFeature
{
    ValueTask<User> DeleteAsync(User user);
}