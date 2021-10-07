using System.IO;
using System.Text.Json;

namespace ProjectSharp.Authorisation.Settings
{
    public class ServiceSettings : IServiceSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}