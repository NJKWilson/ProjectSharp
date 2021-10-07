using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectSharp.Authorisation.Brokers.Database;
using ProjectSharp.Authorisation.Database;
using ProjectSharp.Authorisation.Settings;
using ProtoBuf.Grpc.Server;

namespace ProjectSharp.Authorisation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(ServiceSettingsBuilder.GetServiceSettings("ServiceSettings.json"));
            services.AddSingleton<IDatabaseBroker, DatabaseBroker>();
            services.AddSingleton<ISeedDataService, SeedDataService>();
            services.AddGrpc();
            services.AddCodeFirstGrpc();
        }
        
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            ISeedDataService seedDataService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            seedDataService.SeedAdminUser();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                
                
            });
        }
    }
}