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

        public DatabaseContext(
            DbContextOptions<DatabaseContext> AOptions, 
            IConnectionService AConnectionService) : base(AOptions)
        {
            FConnectionService = AConnectionService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder AOptionsBuilder)
        {
            var ConnectionString = FConnectionService.GetExampleDatabase();

            /// <seealso cref="https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency"/>
            AOptionsBuilder.UseSqlServer(ConnectionString, AddOptions =>
                    AddOptions.EnableRetryOnFailure());
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

        protected void ApplyConfiguration(ModelBuilder AModelBuilder)
        {
            AModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
