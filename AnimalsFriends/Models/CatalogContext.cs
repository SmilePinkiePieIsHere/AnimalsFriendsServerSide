using Microsoft.EntityFrameworkCore;

namespace AnimalsFriends.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
