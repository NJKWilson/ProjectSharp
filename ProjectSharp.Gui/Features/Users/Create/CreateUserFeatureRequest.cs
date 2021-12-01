using System.ComponentModel.DataAnnotations;

namespace ProjectSharp.Gui.Features.Users.Create;

public class CreateUserFeatureRequest
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
    [EmailAddress]
    [StringLength(30, ErrorMessage = "email must be at least 4 characters long.", MinimumLength = 4)]
    public string Email { get; set; } = "";
    
    [Required]
    [StringLength(30, ErrorMessage = "email must be at least 4 characters long.", MinimumLength = 4)]
    public string Password { get; set; } = "";
}