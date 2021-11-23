using ProjectSharp.DataAccess.Entities;
using User = ProjectSharp.Gui.Database.Entities.User;

namespace ProjectSharp.Gui.Core.Brokers.Database.UserBroker;

public interface IUserStorageBroker
{
    ValueTask<User> InsertAsync(User user);
    IQueryable<User> SelectAll();
    ValueTask<User> SelectByIdAsync(Guid userId);
    ValueTask<User> UpdateAsync(User user);
    ValueTask<User> DeleteAsync(User user);
}