using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ProjectSharp.Authorisation.Brokers.Settings;
using ProjectSharp.Authorisation.Settings;
using Xunit;

namespace ProjectSharp.Authorisation.Tests.Brokers.Settings
{
    public class SettingsBrokerTests
    {
        [Fact]
        public void SettingsBroker_SavesAndLoadsSettings_Pass()
        {
            //given
            ISettingsBroker settingsBroker = new SettingsBroker();
            const string filename = "serviceSettingsTest.json";
            var serviceSettingsMock = new ServiceSettings
            {
                Key = "Key",
                Issuer = "Issuer",
                Audience = "Audience",
                ConnectionString = "ConnectionString",
                DatabaseName = "DatabaseName"
            };

            settingsBroker.SaveSettings(filename, serviceSettingsMock);

            var serviceSettingsFromFile = settingsBroker.LoadSettings(filename);

            //when

            //should
            Assert.Equal(serviceSettingsMock.Key, serviceSettingsFromFile.Key);
            Assert.Equal(serviceSettingsMock.Issuer, serviceSettingsFromFile.Issuer);
            Assert.Equal(serviceSettingsMock.Audience, serviceSettingsFromFile.Audience);
            Assert.Equal(serviceSettingsMock.ConnectionString, serviceSettingsFromFile.ConnectionString);
            Assert.Equal(serviceSettingsMock.DatabaseName, serviceSettingsFromFile.DatabaseName);

            File.Delete(filename);
        }
    }
}