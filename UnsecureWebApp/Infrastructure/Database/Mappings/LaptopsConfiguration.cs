using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Infrastructure.Database.Mappings
{
    public class LaptopsConfiguration : IEntityTypeConfiguration<Laptops>
    {
        public void Configure(EntityTypeBuilder<Laptops> AEntityBuilder)
        {
            AEntityBuilder.Property(e => e.Brand)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            AEntityBuilder.Property(e => e.SerialNo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            AEntityBuilder.HasOne(d => d.User)
                .WithMany(p => p.Laptops)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Laptops__UserId");
        }
    }
}
