using System.IO;
using System.Text.Json;
using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Settings
{
    public class SettingsBroker : ISettingsBroker
    {
        public IServiceSettings LoadSettings(string filename = "ServiceSettings.json")
        {
            return JsonSerializer.Deserialize<ServiceSettings>(File.ReadAllText(filename));
        }

        public void SaveSettings(IServiceSettings settings, string filename = "ServiceSettings.json")
        {
            var jwtSettingsString = JsonSerializer.Serialize(settings);

            File.WriteAllText(filename, jwtSettingsString);
        }
    }
}