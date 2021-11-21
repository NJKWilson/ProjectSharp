using FluentValidation;
using MediatR;
using ProjectSharp.Api.Brokers.DateTime;
using ProjectSharp.Api.Brokers.JwtToken;
using ProjectSharp.Api.Brokers.Password;
using ProjectSharp.Api.Endpoints.UserManagement.Create;
using ProjectSharp.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PSharpContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Brokers
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<IJwtTokenBroker, JwtTokenBroker>();
builder.Services.AddTransient<IPasswordBroker, PasswordBroker>();

// Handlers
builder.Services.AddTransient<CreateUserHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();