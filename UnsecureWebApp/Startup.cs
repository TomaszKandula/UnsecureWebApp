using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnsecureWebApp.Infrastructure.Database;
using UnsecureWebApp.Services.ConnectionService;

namespace UnsecureWebApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration AConfiguration)
            => Configuration = AConfiguration;
 
        public void ConfigureServices(IServiceCollection AServices)
        {
            AServices.AddMvc(AOption => AOption.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            AServices.AddRazorPages();
            AServices.AddScoped<IConnectionService, ConnectionService>();
            AServices.AddDbContext<DatabaseContext>();
        }

        public void Configure(IApplicationBuilder AApplication, IWebHostEnvironment AEnvironment)
        {
            if (AEnvironment.IsDevelopment())
                AApplication.UseDeveloperExceptionPage();

            AApplication.UseExceptionHandler("/Error");
            AApplication.UseStaticFiles();
            AApplication.UseRouting();
            AApplication.UseAuthorization();
            AApplication.UseEndpoints(AEndpoints 
                => AEndpoints.MapRazorPages());
        }
    }
}
