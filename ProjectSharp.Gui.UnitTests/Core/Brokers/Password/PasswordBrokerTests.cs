using System;
using ProjectSharp.Gui.Brokers.Password;
using Xunit;
using Xunit.Abstractions;

namespace ProjectSharp.Gui.UnitTests.Core.Brokers.Password;

public class PasswordBrokerTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PasswordBrokerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Init_CurrentUserShouldBeNull()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        IPasswordBroker passwordBroker = new PasswordBroker();
        // When 
        var passwordHash = passwordBroker.HashPassword("admin");
        _testOutputHelper.WriteLine(passwordHash);
            
        // Should
        Assert.True(passwordBroker.VerifyPassword("admin",passwordHash));
        Assert.True(passwordBroker.VerifyPassword("admin","$2a$11$Gwm.VIP9e7UGKD8D.awmlu2oxgnNHQaRfbuVT9PVpEwrc1uuBFok."));
    }
}