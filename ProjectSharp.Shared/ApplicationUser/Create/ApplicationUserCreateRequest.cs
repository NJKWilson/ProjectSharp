namespace ProjectSharp.Shared.ApplicationUser.Create
{
    public class ApplicationUserCreateRequest
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}