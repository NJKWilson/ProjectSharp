using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Routing.Constraints;
using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Settings
{
    public class SettingsBroker : ISettingsBroker
    {
        public IServiceSettings LoadSettings(string filename)
        {
            return JsonSerializer.Deserialize<ServiceSettings>(File.ReadAllText(filename));
        }

        public void SaveSettings(string filename, IServiceSettings settings)
        {
            var jwtSettingsString = JsonSerializer.Serialize(settings);

            File.WriteAllText(filename, jwtSettingsString);
        }
    }
}