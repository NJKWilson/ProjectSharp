using Microsoft.EntityFrameworkCore;
using ProjectSharp.Api.Brokers.JwtToken;
using ProjectSharp.Api.Endpoints.UserManagement.GetById;
using ProjectSharp.DataAccess;

namespace ProjectSharp.Api.Middleware.JwtToken;

public class JwtTokenMiddleware
{
    private readonly RequestDelegate _next;

    public JwtTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        ILogger<JwtTokenMiddleware> logger, 
        HttpContext context, 
        PSharpContext pSharpContext, 
        IJwtTokenBroker jwtTokenBroker)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await AttachUserToContext(logger, context, pSharpContext, jwtTokenBroker, token);

        await _next(context);
    }

    private static async Task AttachUserToContext(
        ILogger<JwtTokenMiddleware> logger,
        HttpContext context, 
        PSharpContext userService, 
        IJwtTokenBroker tokenService, 
        string token)
    {
        try
        {
            // todo sort out the issuer, audience and signing key
            var userId = tokenService.ValidateToken("mee", "","",token);
            
            context.Items["User"] = await userService.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }
        catch
        {
            logger.LogWarning($"Failed to verify Jwt Token");
        }
    }
}