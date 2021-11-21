using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSharp.DataAccess.Entities;

/// <summary>
/// Use UserRole Enum to set role.
/// </summary>
public class User : IAuditable
{
    [Key]
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public virtual User CreatedBy { get; set; } = new User();
    public virtual User? UpdatedBy { get; set; }
}