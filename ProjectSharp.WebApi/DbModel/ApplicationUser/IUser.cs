namespace ProjectSharp.WebApi.DbModel.ApplicationUser
{
    public interface IUser: IEntity, IAuditable
    {
        string FirstName { get; set; }
        string FamilyName { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Role { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
    }
}