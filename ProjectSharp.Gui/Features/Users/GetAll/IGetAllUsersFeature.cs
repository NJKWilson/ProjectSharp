using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Users.GetAll;

public interface IGetAllUsersFeature
{
    IQueryable<User> SelectAll();
}