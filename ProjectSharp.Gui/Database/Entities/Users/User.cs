using System.ComponentModel.DataAnnotations;

namespace ProjectSharp.Gui.Database.Entities.Users;

/// <summary>
///     Use UserRole Enum to set role.
/// </summary>
public class User : IAuditable
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public User? CreatedBy { get; set; }
    public User? UpdatedBy { get; set; }
}