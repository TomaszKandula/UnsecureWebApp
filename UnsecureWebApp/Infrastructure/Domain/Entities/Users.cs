using System.Collections.Generic;

namespace UnsecureWebApp.Infrastructure.Domain.Entities
{
    public class Users : Entity<int>
    {
        public string EmailAddress { get; set; }

        public string HashedPassword { get; set; }

        public virtual ICollection<Laptops> Laptops { get; set; } = new HashSet<Laptops>();
    }
}
