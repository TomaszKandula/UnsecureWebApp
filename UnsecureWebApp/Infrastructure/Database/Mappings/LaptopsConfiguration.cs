using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Infrastructure.Database.Mappings
{
    public class LaptopsConfiguration : IEntityTypeConfiguration<Laptops>
    {
        public void Configure(EntityTypeBuilder<Laptops> AEntityBuilder)
        {
            AEntityBuilder.Property(ALaptops => ALaptops.Brand)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            AEntityBuilder.Property(ALaptops => ALaptops.SerialNo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            AEntityBuilder.HasOne(ALaptops => ALaptops.User)
                .WithMany(ALaptops => ALaptops.Laptops)
                .HasForeignKey(ALaptops => ALaptops.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Laptops__UserId");
        }
    }
}
