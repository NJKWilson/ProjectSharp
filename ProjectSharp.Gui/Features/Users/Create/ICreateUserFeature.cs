using ProjectSharp.DataAccess.Entities;
using User = ProjectSharp.Gui.Database.Entities.User;

namespace ProjectSharp.Gui.Features.Users.Create;

public interface ICreateUserFeature
{
    ValueTask<User> InsertAsync(CreateUserFeatureRequest user);
}