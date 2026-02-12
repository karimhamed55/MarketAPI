using Microsoft.EntityFrameworkCore;
namespace webAPI.data
{
    public class MarketDbContext: DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options): base(options)
        { } public DbSet<Product> Products { get; set; }


    }
}
