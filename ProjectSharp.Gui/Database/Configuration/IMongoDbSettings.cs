namespace ProjectSharp.Gui.Database.Configuration;

public interface IMongoDbSettings
{
    string? ConnectionString { get; set; }
    string? DatabaseName { get; set; }
    string? UsersCollectionName { get; set; }
}