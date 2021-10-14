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
            var stringHashBroker = new StringHashBroker();
            const string testPassword = "testPassword";

            //when

            var hashedPassword = stringHashBroker.HashString(testPassword);

            //should
            Assert.True(stringHashBroker.VerifyHashedString(testPassword, hashedPassword));
        }
    }
}