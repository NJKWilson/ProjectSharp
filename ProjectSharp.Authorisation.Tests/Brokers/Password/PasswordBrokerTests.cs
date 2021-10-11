using System.Threading.Tasks;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Services;
using ProjectSharp.Shared.Grpc;
using Xunit;

namespace ProjectSharp.Authorisation.Tests.Brokers.Password
{
    public class PasswordBrokerTests
    {
        [Fact]
        public void PasswordBroker_GeneratesAndVerifiesPassword_Pass()
        {
            //given
            var passwordBroker = new PasswordBroker();
            var testPassword = "testPassword";

            //when

            var (hashedPassword, salt) = passwordBroker.HashPassword(testPassword);

            //should
            Assert.True(passwordBroker.VerifyPassword(testPassword, hashedPassword));
        }
    }
}