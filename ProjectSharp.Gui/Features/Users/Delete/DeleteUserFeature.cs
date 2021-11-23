using Microsoft.EntityFrameworkCore;
using ProjectSharp.DataAccess;
using ProjectSharp.DataAccess.Entities;
using ProjectSharp.Gui.Features.Users.Delete.Exceptions;

namespace ProjectSharp.Gui.Features.Users.Delete;

public class DeleteUserFeature : IDeleteUserFeature
{
    private readonly PSharpContext _pSharpContext;

    public DeleteUserFeature(PSharpContext pSharpContext)
    {
        _pSharpContext = pSharpContext;
    }
    
    public async ValueTask<User> DeleteAsync(User user)
    {
        // Validation
        if (user.Id == Guid.Empty)
            throw new DeleteUserFeatureUserDoesNotExistException();

        // Check user does exist.
        var maybeUser = await _pSharpContext.Users.FirstOrDefaultAsync(
            u => u.Id == user.Id);
        if (maybeUser is null)
            throw new DeleteUserFeatureUserDoesNotExistException();
        
        // Try to save to database
        try
        {
            _pSharpContext.Users.Remove(maybeUser);
            await _pSharpContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw new DeleteUserFeatureDatabaseException("Database Exception", exception);
        }

        return maybeUser;
    }
}