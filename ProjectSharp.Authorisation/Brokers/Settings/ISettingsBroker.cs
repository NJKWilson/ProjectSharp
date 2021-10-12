using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Settings
{
    public interface ISettingsBroker
    {
        IServiceSettings LoadSettings(string filename = "ServiceSettings.json");
        void SaveSettings(IServiceSettings settings, string filename = "ServiceSettings.json");
    }
}