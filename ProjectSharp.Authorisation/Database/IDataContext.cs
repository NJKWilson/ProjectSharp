using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Database
{
    public interface IDataContext
    {
        IMongoCollection<User> Users { get; }
    }
}