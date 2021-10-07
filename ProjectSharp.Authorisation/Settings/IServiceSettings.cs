namespace ProjectSharp.Authorisation.Settings
{
    public interface IServiceSettings
    {
        string Key { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}