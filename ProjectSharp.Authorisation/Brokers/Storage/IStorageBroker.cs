using MongoDB.Driver;

namespace ProjectSharp.Authorisation.Brokers.Storage
{
    public interface IStorageBroker
    {
        IMongoDatabase Database { get; }
    }
}