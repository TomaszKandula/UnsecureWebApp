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
                    Brand = "Lenovo",
                    SerialNo = "C02L456987",
                    UserId = 1
                },
                new Laptops
                {
                    Id = 2,
                    Brand = "Dell",
                    SerialNo = "123AB458GH",
                    UserId = 2
                },
                new Laptops
                {
                    Id = 3,
                    Brand = "HP",
                    SerialNo = "PO54654PUXR",
                    UserId = 2
                }
            );
        }
    }
}
