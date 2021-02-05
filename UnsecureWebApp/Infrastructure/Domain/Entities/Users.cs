using System.Collections.Generic;

namespace UnsecureWebApp.Infrastructure.Domain.Entities
{
    public class Users : Entity<int>
    {
        public Users()
        {
            Laptops = new HashSet<Laptops>();
        }

        public string EmailAddress { get; set; }

        public string HashedPassword { get; set; }

        public virtual ICollection<Laptops> Laptops { get; set; }
    }
}
