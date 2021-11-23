using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Gui.Features.Users.Create;

public interface ICreateUserFeature
{
    ValueTask<User> InsertAsync(CreateUserFeatureRequest user);
}