using ProjectSharp.Authorisation.Brokers.Password;
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
            const string testPassword = "testPassword";

            //when

            var hashedPassword = passwordBroker.HashPassword(testPassword);

            //should
            Assert.True(passwordBroker.VerifyPassword(testPassword, hashedPassword));
        }
    }
}