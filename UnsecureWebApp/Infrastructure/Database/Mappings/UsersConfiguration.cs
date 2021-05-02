using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Infrastructure.Database.Mappings
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> AEntityBuilder)
        {
            AEntityBuilder.Property(AUsers => AUsers.EmailAddress)
                .IsRequired()
                .HasMaxLength(255);

            AEntityBuilder.Property(AUsers => AUsers.HashedPassword)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
