using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectSharp.Authorisation.Brokers.Database;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Brokers.Settings;
using ProjectSharp.Authorisation.Entities.User;
using ProjectSharp.Authorisation.Migrations;
using ProtoBuf.Grpc.Server;

namespace ProjectSharp.Authorisation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            services.AddSingleton<IDatabaseBroker, DatabaseBroker>();
            services.AddSingleton<IStringHashBroker, StringHashBroker>();
            services.AddTransient<ISettingsBroker, SettingsBroker>();

            //services.AddSingleton<IDataContext, DataContext>();
            //services.AddTransient<ISeedDataService, SeedDataService>();
            
            
            services.AddIdentity<User, UserRole>()
                .AddMongoDbStores<User, UserRole, Guid>
                (
                    connectionString, "identity"
                );
            
            services.AddGrpc();
            services.AddCodeFirstGrpc();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                logger.LogInformation("Running in Development!");
            }

            SeedAdminUser.SeedAdmin(userManager, roleManager, logger);

            app.UseRouting();

            app.UseEndpoints(endpoints => { });
        }
    }
}