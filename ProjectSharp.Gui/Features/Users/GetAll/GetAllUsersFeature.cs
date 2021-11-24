using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Features.Users.GetAll;

public class GetAllUsersFeature : IGetAllUsersFeature
{
    private readonly PSharpContext _pSharpContext;

    public GetAllUsersFeature(PSharpContext pSharpContext)
    {
        _pSharpContext = pSharpContext;
    }

    public IQueryable<User> SelectAll()
    {
        return _pSharpContext.Users.AsQueryable();
    }
}