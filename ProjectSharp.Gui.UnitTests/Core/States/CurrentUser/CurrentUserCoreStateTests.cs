using System;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Auth;
using Xunit;

namespace ProjectSharp.Gui.UnitTests.Core.States.CurrentUser;

public class CurrentUserCoreStateTests
{
    [Fact]
    public void Init_CurrentUserShouldBeNull()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        AuthenticationState authenticationState;
        // When 
        authenticationState = new AuthenticationState();
        
        // Should
        Assert.Null(authenticationState.CurrentUser);
    }
    
    [Fact]
    public void NoUserAuthenticated_AllChecksReturnFalse()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        AuthenticationState authenticationState;
        // When 
        authenticationState = new AuthenticationState();
        
        // Should
        Assert.False(authenticationState.IsAuthenticated);
        Assert.False(authenticationState.IsAdmin);
        Assert.False(authenticationState.IsUser);
        Assert.False(authenticationState.IsLocked);
    }
    
    [Fact]
    public void LoginUser_CurrentUserIsNotNull()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        var currentUserCoreState = new AuthenticationState();
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin",
            Password = "",
            Role = UserRole.Admin.ToString()
        };
        
        // When 
        currentUserCoreState.LoginUser(user);
        
        // Should
        Assert.NotNull(currentUserCoreState.CurrentUser);
    }
    
    [Fact]
    public void LoginUser_AdminUser_AdminCheckReturnTrue()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        var currentUserCoreState = new AuthenticationState();
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin",
            Password = "",
            Role = UserRole.Admin.ToString()
        };
        
        // When 
        currentUserCoreState.LoginUser(user);
        
        // Should
        Assert.True(currentUserCoreState.IsAdmin);
    }
    
    [Fact]
    public void LoginUser_UserUser_AdminCheckReturnFalse()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        var currentUserCoreState = new AuthenticationState();
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin",
            Password = "",
            Role = UserRole.User.ToString()
        };
        
        // When 
        currentUserCoreState.LoginUser(user);
        
        // Should
        Assert.False(currentUserCoreState.IsAdmin);
    }
}