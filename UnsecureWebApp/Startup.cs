using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UnityApi.Extensions.ConnectionService;
using UnsecureWebApp.Model.Database;

namespace UnsecureWebApp
{
 
    public class Startup
    {

        public IConfiguration FConfiguration { get; }

        public Startup(IConfiguration AConfiguration)
        {
            FConfiguration = AConfiguration;
        }

        public void ConfigureServices(IServiceCollection AServices)
        {

            // Add MVC
            AServices.AddMvc(Option => Option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            AServices.AddRazorPages();

            // Register (a'priori) connection service holding connection string(s) to database(s)
            AServices.AddScoped<IConnectionService, ConnectionService>();

            // Example operational database
            AServices.AddDbContext<DbModel>();

        }

        public void Configure(IApplicationBuilder AApp, IWebHostEnvironment AEnv)
        {

            if (AEnv.IsDevelopment())
            {
                AApp.UseDeveloperExceptionPage();
            }
            else
            {
                AApp.UseExceptionHandler("/Error");
            }

            AApp.UseStaticFiles();
            AApp.UseRouting();
            AApp.UseAuthorization();

            AApp.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

        }
    }

}
