using Microsoft.EntityFrameworkCore;
using UnityApi.Extensions.ConnectionService;

namespace UnsecureWebApp.Model.Database
{
    public partial class DbModel : DbContext
    {
        private readonly IConnectionService FConnectionService;

        public DbModel(DbContextOptions<DbModel> options, IConnectionService AConnectionService) : base(options)
        {
            FConnectionService = AConnectionService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = FConnectionService.GetExampleDatabase();

            /// <seealso cref="https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency"/>
            optionsBuilder.UseSqlServer(ConnectionString, AddOptions =>
                    AddOptions.EnableRetryOnFailure());
        }

        public virtual DbSet<Laptops> Laptops { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptops>(entity =>
            {
                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Laptops)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Laptops__UserId__4E88ABD4");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HashedPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);   
    }
}
