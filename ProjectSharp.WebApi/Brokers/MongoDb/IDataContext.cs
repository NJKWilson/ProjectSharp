using MongoDB.Driver;
using ProjectSharp.WebApi.DbModel.ApplicationUser;

namespace ProjectSharp.WebApi.Brokers.MongoDb
{
    public interface IDataContext
    {
        IMongoCollection<User> Users { get; }
    }
}