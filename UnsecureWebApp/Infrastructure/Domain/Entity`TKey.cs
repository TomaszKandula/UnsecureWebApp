using System.ComponentModel.DataAnnotations;

namespace UnsecureWebApp.Infrastructure.Domain
{
    public abstract class Entity<TKey>
    {
        [Key]
        public int Id { get; set; }
    }
}
