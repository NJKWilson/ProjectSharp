namespace ProjectSharp.Authorisation.Entities
{
    public interface IUser : IEntity, IAuditable
    {
    string FirstName { get; set; }
    string FamilyName { get; set; }
    string Email { get; set; }
    string Role { get; set; }
    string PasswordHash { get; set; }
    }
}