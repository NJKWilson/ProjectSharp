using ProjectSharp.Gui.Core.States.CurrentUser;
using ProjectSharp.Gui.Database;
using ProjectSharp.Gui.Features.Auth.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<PSharpContext>();
builder.Services.AddSingleton<CurrentUserCoreState>();
builder.Services.AddSingleton<UsersState>();
builder.Services.AddTransient<ILoginAuthFeature, LoginAuthFeature>();

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