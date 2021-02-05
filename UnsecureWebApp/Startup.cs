using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            AServices.AddMvc(Option => Option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            AServices.AddRazorPages();
            AServices.AddScoped<IConnectionService, ConnectionService>();
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
