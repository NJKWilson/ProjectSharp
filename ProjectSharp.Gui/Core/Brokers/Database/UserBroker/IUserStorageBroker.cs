using ProjectSharp.Gui.Database.Entities;
using ProjectSharp.Gui.Database.Entities.Users;

namespace ProjectSharp.Gui.Core.Brokers.Database.UserBroker;

public interface IUserStorageBroker
{
    ValueTask<User> InsertAsync(User user);
    IQueryable<User> SelectAll();
    ValueTask<User> SelectByIdAsync(Guid userId);
    ValueTask<User> UpdateAsync(User user);
    ValueTask<User> DeleteAsync(User user);
}