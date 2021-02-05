using Microsoft.EntityFrameworkCore;

namespace UnsecureWebApp.Infrastructure.Database.Seeders
{
    public interface IDatabaseContextSeeder
    {
        void Seed(ModelBuilder AModelBuilder);
    }
}
