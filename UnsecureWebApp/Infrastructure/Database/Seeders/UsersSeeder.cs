using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UnsecureWebApp.Infrastructure.Domain.Entities;

namespace UnsecureWebApp.Infrastructure.Database.Seeders
{
    public class UsersSeeder : IDatabaseContextSeeder
    {
        public void Seed(ModelBuilder AModelBuilder)
            => AModelBuilder.Entity<Users>().HasData(CreateUserList());

        private static IEnumerable<Users> CreateUserList()
        {
            return new List<Users>
            {
                new Users 
                { 
                    Id = 1,
                    EmailAddress = "jonny@example.com",
                    HashedPassword = "password1234"
                },
                new Users 
                {
                    Id = 2,
                    EmailAddress = "bravo@example.com",
                    HashedPassword = "admin2020"
                }
            };
        }
    }
}
