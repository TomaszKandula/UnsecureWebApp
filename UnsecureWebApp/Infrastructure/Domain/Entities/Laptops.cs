namespace UnsecureWebApp.Infrastructure.Domain.Entities
{
    public class Laptops : Entity<int>
    {
        public string Brand { get; set; }

        public string SerialNo { get; set; }

        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
