using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Users.Create;

public interface ICreateUserFeature
{
    ValueTask<User> InsertAsync(CreateUserFeatureRequest createUserFeatureRequest, User creatingUser);
}