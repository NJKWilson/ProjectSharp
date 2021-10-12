using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectSharp.Authorisation.Brokers.Database;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Brokers.Settings;
using ProjectSharp.Authorisation.Database;
using ProtoBuf.Grpc.Server;

namespace ProjectSharp.Authorisation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseBroker, DatabaseBroker>();
            services.AddSingleton<IPasswordBroker, PasswordBroker>();
            services.AddSingleton<ISettingsBroker, SettingsBroker>();

            //services.AddSingleton<IDataContext, DataContext>();
            services.AddSingleton<ISeedDataService, SeedDataService>();
            services.AddGrpc();
            services.AddCodeFirstGrpc();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ISeedDataService seedDataService,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                logger.LogInformation("Running in Development!");
            }

            seedDataService.SeedAdminUser();

            app.UseRouting();

            app.UseEndpoints(endpoints => { });
        }
    }
}