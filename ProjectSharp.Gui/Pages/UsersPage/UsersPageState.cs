using System.ComponentModel.DataAnnotations;
using ProjectSharp.Gui.Database.Entities.Users;
using ProjectSharp.Gui.Features.Users.Create;

namespace ProjectSharp.Gui.Pages.UsersPage;

// todo rename to UsersPageState
public class UsersPageState
{
    public bool EditUserFlyoutOpen { get; set; }
    public bool CreateUserFlyoutOpen { get; set; }
    public CreateUserFeatureRequest CreateUserFeatureRequest { get; set; } = new CreateUserFeatureRequest();
    public EditUserFormModel EditUserModel { get; set; } = new EditUserFormModel();
    public User UserToEdit { get; set; } = new User();
    public event Action? OnChange;

    // EditUserFlyout
    public void OpenEditUserFlyout(User userToEdit)
    {
        UserToEdit = userToEdit;
        EditUserModel.FirstName = UserToEdit.FirstName;
        EditUserModel.LastName = UserToEdit.LastName;
        EditUserModel.Email = UserToEdit.Email;
        EditUserModel.JobTitle = UserToEdit.JobTitle;
        EditUserModel.Role = UserToEdit.Role;
        EditUserFlyoutOpen = true;
        NotifyStateChanged();
    }
    
    public void CloseEditUserFlyout()
    {
        UserToEdit = new User();
        EditUserModel.FirstName = UserToEdit.FirstName;
        EditUserModel.LastName = UserToEdit.LastName;
        EditUserModel.Email = UserToEdit.Email;
        EditUserModel.JobTitle = UserToEdit.JobTitle;
        EditUserModel.Role = UserToEdit.Role;
        EditUserFlyoutOpen = false;
        NotifyStateChanged();
    }
    
    public void OpenCreateUserFlyout()
    {
        CreateUserFlyoutOpen = true;
        NotifyStateChanged();
    }
    
    public void CloseCreateUserFlyout()
    {
        UserToEdit = new User();
        CreateUserFlyoutOpen = false;
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}

public class EditUserFormModel
{
    [Required]
    [StringLength(30, ErrorMessage = "First name must be at least 4 characters long.", MinimumLength = 4)]
    public string FirstName { get; set; } = "";

    [Required]
    [StringLength(30, ErrorMessage = "Last name must be at least 4 characters long.", MinimumLength = 4)]
    public string LastName { get; set; } = "";
        
    [Required]
    [StringLength(30, ErrorMessage = "Job title must be at least 4 characters long.", MinimumLength = 4)]
    public string JobTitle { get; set; } = "";
        
    [Required]
    [StringLength(30, ErrorMessage = "email must be at least 4 characters long.", MinimumLength = 4)]
    public string Email { get; set; } = "";
        
    [Required]
    [StringLength(30, ErrorMessage = "Role must be at least 4 characters long.", MinimumLength = 4)]
    public string Role { get; set; } = "";
}