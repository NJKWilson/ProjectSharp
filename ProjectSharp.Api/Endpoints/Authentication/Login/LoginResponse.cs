namespace ProjectSharp.Api.Endpoints.Authentication.Login;

public class LoginResponse
{
    public string? JwtKey { get; set; }
    public string? JwtRefreshKey { get; set; }
}