using Microsoft.EntityFrameworkCore;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Infrastructure.Database.Seeders
{
    public class LaptopsSeeder : IDatabaseContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<Laptops>().HasData(
                new Laptops 
                { 
                    Id = 1,
                    Brand = "Dell",
                    SerialNo = "ABCDE",
                    UserId = 1
                },
                new Laptops
                {
                    Id = 2,
                    Brand = "HP",
                    SerialNo = "ECDBA",
                    UserId = 1
                },
                new Laptops
                {
                    Id = 3,
                    Brand = "Lenovo",
                    SerialNo = "987456AE",
                    UserId = 2
                }
            );
        }
    }
}
