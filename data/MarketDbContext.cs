using Microsoft.EntityFrameworkCore;
using webAPI.Model;
namespace webAPI.data
{
    public class MarketDbContext: DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options): base(options)
        { } public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        // seeding the admin
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 55,
                Name = "admin",
                Email = "admin@market.com",
                Password = "adminpassword123",
                Role = "Admin"
            });
        }

    }
}
