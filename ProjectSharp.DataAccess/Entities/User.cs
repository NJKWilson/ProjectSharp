using System.ComponentModel.DataAnnotations;

namespace ProjectSharp.DataAccess.Entities;

/// <summary>
/// Use UserRole Enum to set role.
/// </summary>
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}