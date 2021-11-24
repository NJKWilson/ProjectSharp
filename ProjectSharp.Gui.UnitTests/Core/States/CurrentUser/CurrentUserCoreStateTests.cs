using System;
using ProjectSharp.Gui.Core.States.CurrentUser;
using ProjectSharp.Gui.Database.Entities.Users;
using Xunit;

namespace ProjectSharp.Gui.UnitTests.Core.States.CurrentUser;

public class CurrentUserCoreStateTests
{
    [Fact]
    public void Init_CurrentUserShouldBeNull()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        CurrentUserCoreState currentUserCoreState;
        // When 
        currentUserCoreState = new CurrentUserCoreState();
        
        // Should
        Assert.Null(currentUserCoreState.CurrentUser);
    }
    
    [Fact]
    public void NoUserAuthenticated_AllChecksReturnFalse()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        CurrentUserCoreState currentUserCoreState;
        // When 
        currentUserCoreState = new CurrentUserCoreState();
        
        // Should
        Assert.False(currentUserCoreState.IsAuthenticated);
        Assert.False(currentUserCoreState.IsAdmin);
        Assert.False(currentUserCoreState.IsUser);
        Assert.False(currentUserCoreState.IsLocked);
    }
    
    [Fact]
    public void LoginUser_CurrentUserIsNotNull()
    {
        // Given
        // ReSharper disable once JoinDeclarationAndInitializer
        var currentUserCoreState = new CurrentUserCoreState();
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
        var currentUserCoreState = new CurrentUserCoreState();
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
        var currentUserCoreState = new CurrentUserCoreState();
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