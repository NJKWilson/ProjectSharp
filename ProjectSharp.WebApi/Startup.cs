using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProjectSharp.WebApi.Brokers.MongoDb;
using ProjectSharp.WebApi.Common.AppSettings;
using ProjectSharp.WebApi.Common.Middleware;
using ProjectSharp.WebApi.Configuration.MongoDb;
using ProjectSharp.WebApi.Features.ApplicationUser.Authenticate;

namespace ProjectSharp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Get configuration settings from appsettings.json and create strongly typed settings objects
            services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));
            services.Configure<IMongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            
            // Add the settings objects to di container
            services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<IMongoDbSettings>>().Value);
            
            services.AddSingleton<IDataContext, DataContext>();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ProjectSharp.WebApi", Version = "v1"});
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectSharp.WebApi v1"));
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}