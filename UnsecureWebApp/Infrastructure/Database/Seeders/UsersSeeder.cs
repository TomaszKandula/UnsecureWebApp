using Microsoft.EntityFrameworkCore;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Infrastructure.Database.Seeders
{
    public class UsersSeeder : IDatabaseContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
        {
            AModelBuilder.Entity<Users>().HasData(           
                new Users 
                { 
                    Id = 1,
                    EmailAddress = "tokan@dfds.com",
                    HashedPassword = "123456"
                },
                new Users 
                {
                    Id = 2,
                    EmailAddress = "tokan@gmail.com",
                    HashedPassword = "654321"
                }
            );
        }
    }
}
