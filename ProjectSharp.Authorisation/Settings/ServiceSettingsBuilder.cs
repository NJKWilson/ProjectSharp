using System.IO;
using System.Text.Json;

namespace ProjectSharp.Authorisation.Settings
{
    public static class ServiceSettingsBuilder
    {
        public static IServiceSettings GetServiceSettings(string fileName)
        {
            var jwtSettings = 
                JsonSerializer.Deserialize<ServiceSettings>(File.ReadAllText(fileName));

            return jwtSettings;
        }
    }
}