using System;
using ProjectSharp.Gui.Core.Brokers.Password;
using ProjectSharp.Gui.Core.States.CurrentUser;
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
        
        // Should
        _testOutputHelper.WriteLine(passwordHash);
    }
}