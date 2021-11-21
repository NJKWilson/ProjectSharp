using FluentValidation;
using MediatR;
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

// todo Implement brokers
// todo add bcrypt nuget
// todo implement auditable base entity
// todo seed admin user in dbcontext
// todo implement jwtStuff
// todo decide if you want to do middleware
// todo bearer token in headers or jwt in request body