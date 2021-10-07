using ProjectSharp.Authorisation.Settings;

namespace ProjectSharp.Authorisation.Brokers.Settings
{
    public interface ISettingsBroker
    {
        IServiceSettings LoadSettings();
        void SaveSettings(IServiceSettings settings);
    }
}