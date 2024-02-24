using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Products_API.Model
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
        {   }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
