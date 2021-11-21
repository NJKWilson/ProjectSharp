using Microsoft.EntityFrameworkCore;
using ProjectSharp.Api.Brokers.DateTime;
using ProjectSharp.Api.Brokers.Password;
using ProjectSharp.Api.Endpoints.UserManagement.Create.Exceptions;
using ProjectSharp.DataAccess;
using ProjectSharp.DataAccess.Entities;
using ProjectSharp.DataAccess.Enums;

namespace ProjectSharp.Api.Endpoints.UserManagement.Create;

public class CreateUserHandler
{
    private readonly PSharpContext _pSharpContext;
    private readonly IPasswordBroker _passwordBroker;
    private readonly IDateTimeBroker _dateTimeBroker;

    public CreateUserHandler(PSharpContext pSharpContext, IPasswordBroker passwordBroker, IDateTimeBroker dateTimeBroker)
    {
        _pSharpContext = pSharpContext;
        _passwordBroker = passwordBroker;
        _dateTimeBroker = dateTimeBroker;
    }

    public async ValueTask<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest, User creatingUser)
    {
        if (string.IsNullOrWhiteSpace(createUserRequest.Email) || string.IsNullOrWhiteSpace(createUserRequest.Password))
            throw new CreateUserHandlerBadRequestException();
        
        // Check if email is already used
        var maybeUser = await _pSharpContext.Users.FirstOrDefaultAsync(user => user.Email == createUserRequest.Email);
        if (maybeUser is not null)
            throw new CreateUserHandlerUserAlreadyExistsException(maybeUser);
        
        // Create the new User model
        var newUser = new User
        {
            Email = createUserRequest.Email,
            Password = _passwordBroker.HashPassword(createUserRequest.Password),
            Role = UserRole.Locked.ToString(),
            CreatedBy = creatingUser,
            CreatedOn = _dateTimeBroker.TimeNow()
        };

        try
        {
            await _pSharpContext.Users.AddAsync(newUser);
            await _pSharpContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw new CreateUserHandlerDependencyException("Database Dependency Exception", exception);
        }

        return new CreateUserResponse(newUser);
    }
}