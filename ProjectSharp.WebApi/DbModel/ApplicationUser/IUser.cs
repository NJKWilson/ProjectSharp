namespace ProjectSharp.WebApi.DbModel.ApplicationUser
{
    public interface IUser: IEntity, IAuditable
    {
        string Username { get; set; }
        string Email { get; set; }
        string Role { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
    }
}