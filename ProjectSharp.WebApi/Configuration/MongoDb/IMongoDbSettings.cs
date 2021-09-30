namespace ProjectSharp.WebApi.Configuration.MongoDb
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}