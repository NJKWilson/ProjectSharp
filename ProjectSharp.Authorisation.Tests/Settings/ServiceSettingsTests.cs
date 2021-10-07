using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Configuration;
using ProjectSharp.Authorisation.Services;
using ProjectSharp.Authorisation.Settings;
using ProjectSharp.Shared.Grpc;
using Xunit;

namespace ProjectSharp.Authorisation.Tests.Settings
{
    public class ServiceSettingsTests
    {
        [Fact]
        public async Task AuthorisationService_Throws_NotImplemented()
        {
            //given
            var serviceSettingsMock = new ServiceSettings
            {
                Key = "Key",
                Issuer = "Issuer",
                Audience = "Audience",
                ConnectionString = "ConnectionString",
                DatabaseName = "DatabaseName"
            };

            var jwtSettingsJsonString =
                JsonSerializer.Serialize(serviceSettingsMock);

            File.WriteAllText("serviceSettingsTest.json", jwtSettingsJsonString);


            
            var serviceSettingsFromFile = ServiceSettingsBuilder.GetServiceSettings("serviceSettingsTest.json");
            
            //when

            //should
            Assert.Equal(serviceSettingsMock.Key, serviceSettingsFromFile.Key);
            Assert.Equal(serviceSettingsMock.Issuer, serviceSettingsFromFile.Issuer);
            Assert.Equal(serviceSettingsMock.Audience, serviceSettingsFromFile.Audience);
            Assert.Equal(serviceSettingsMock.ConnectionString, serviceSettingsFromFile.ConnectionString);
            Assert.Equal(serviceSettingsMock.DatabaseName, serviceSettingsFromFile.DatabaseName);
            
            File.Delete("serviceSettingsTest.json");
        }
    }
}