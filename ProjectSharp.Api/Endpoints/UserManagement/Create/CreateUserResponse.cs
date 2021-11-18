using ProjectSharp.DataAccess.Entities;

namespace ProjectSharp.Api.Endpoints.UserManagement.Create;

public class CreateUserResponse
{
    public Guid Id { get; }
    public string? Email { get; }
    public string? Role { get; }
    
    public CreateUserResponse(User user)
    {
        Id = user.Id;
        Email = user.Email;
        Role = user.Role;
    }
}