using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UnsecureWebApp.Services.ConnectionService;
using UnsecureWebApp.Infrastructure.Domain.Entities;
using UnsecureWebApp.Infrastructure.Database.Seeders;

namespace UnsecureWebApp.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConnectionService FConnectionService;

        public DatabaseContext(DbContextOptions<DatabaseContext> AOptions, IConnectionService AConnectionService) : base(AOptions)
            => FConnectionService = AConnectionService;

        /// <seealso href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency"/>
        /// <param name="AOptionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder AOptionsBuilder)
        {
            var LConnectionString = FConnectionService.GetExampleDatabase();

            AOptionsBuilder.UseSqlServer(LConnectionString, ADdOptions 
                => ADdOptions.EnableRetryOnFailure());
        }

        public virtual DbSet<Laptops> Laptops { get; set; }
        
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder AModelBuilder)
        {
            base.OnModelCreating(AModelBuilder);
            ApplyConfiguration(AModelBuilder);

            new UsersSeeder().Seed(AModelBuilder);
            new LaptopsSeeder().Seed(AModelBuilder);
        }

        private static void ApplyConfiguration(ModelBuilder AModelBuilder)
            => AModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
