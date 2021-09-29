namespace ProjectSharp.WebApi.DbModel.ApplicationUser
{
    public interface IUser: IEntity, IAuditable
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }
    }
}