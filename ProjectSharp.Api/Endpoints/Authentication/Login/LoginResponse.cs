namespace ProjectSharp.Api.Endpoints.Authentication.Login;

public class LoginResponse
{
    public bool Success { get; set; }
    public string? Errors { get; set; }
    public InnerLoginResponse? Response { get; set; }
}

public class InnerLoginResponse
{
    public string? JwtKey { get; set; }
    public string? JwtRefreshKey { get; set; }
}