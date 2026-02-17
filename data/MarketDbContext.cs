using Microsoft.EntityFrameworkCore;
using webAPI.Model;
namespace webAPI.data
{
    public class MarketDbContext: DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options): base(options)
        { } public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
