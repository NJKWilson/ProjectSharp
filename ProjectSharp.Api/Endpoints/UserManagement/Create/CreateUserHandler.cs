using Microsoft.EntityFrameworkCore;
using ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;
using ProjectSharp.DataAccess;
using ProjectSharp.DataAccess.Entities;
using ProjectSharp.DataAccess.Enums;

namespace ProjectSharp.Api.Endpoints.UserManagement.Create;

public class CreateUserHandler
{
    private readonly PSharpContext _pSharpContext;

    public CreateUserHandler(PSharpContext pSharpContext)
    {
        _pSharpContext = pSharpContext;
    }

    public async ValueTask<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest)
    {
        // todo validate input
        
        // Check if email is already used
        var maybeUser = await _pSharpContext.Users.FirstOrDefaultAsync(user => user.Email == createUserRequest.Email);
        if (maybeUser is not null)
            throw new CreateUserHandlerUserAlreadyExistsException(
                $"Email address '{createUserRequest.Email}' already registered.");
        
        // todo hash password
        // Create the new User model
        var newUser = new User
        {
            Email = createUserRequest.Email,
            Password = createUserRequest.Password,
            Role = UserRole.Locked.ToString()
        };

        await _pSharpContext.Users.AddAsync(newUser);
        await _pSharpContext.SaveChangesAsync();

        return new CreateUserResponse(newUser);
    }
}