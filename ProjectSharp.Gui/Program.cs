using MudBlazor.Services;
using ProjectSharp.Gui.Brokers.DateTime;
using ProjectSharp.Gui.Brokers.Password;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Database.Configuration;
using ProjectSharp.Gui.Features.Auth;
using ProjectSharp.Gui.Features.Auth.Login;
using ProjectSharp.Gui.Features.Users.Create;
using ProjectSharp.Gui.Features.Users.GetAll;
using ProjectSharp.Gui.Pages.UsersPage;
using ProjectSharp.Gui.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

// Db
var mongoDbSettings = new MongoDbSettings();
builder.Configuration.GetSection(nameof(MongoDbSettings)).Bind(mongoDbSettings);

builder.Services.AddSingleton<IMongoDbSettings>(mongoDbSettings);
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();

// States
builder.Services.AddSingleton<AuthenticationState>();
builder.Services.AddSingleton<ThemeState>();
builder.Services.AddSingleton<UsersPageState>();

// Features
builder.Services.AddTransient<ILoginAuthFeature, LoginAuthFeature>();
builder.Services.AddTransient<ICreateUserFeature, CreateUserFeature>();
builder.Services.AddTransient<IGetAllUsersFeature, GetAllUsersFeature>();

// Brokers
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<IPasswordBroker, PasswordBroker>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

// todo database speed tests login takes ages