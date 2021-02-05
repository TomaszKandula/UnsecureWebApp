using System.Collections.Generic;

namespace UnsecureWebApp.Model.Database
{
    public partial class Users
    {
        public Users()
        {
            Laptops = new HashSet<Laptops>();
        }

        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string HashedPassword { get; set; }

        public virtual ICollection<Laptops> Laptops { get; set; }
    }
}
