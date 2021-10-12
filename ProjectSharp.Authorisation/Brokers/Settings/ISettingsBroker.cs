using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Settings
{
    public interface ISettingsBroker
    {
        IServiceSettings LoadSettings(string filename);
        void SaveSettings(string filename, IServiceSettings settings);
    }
}