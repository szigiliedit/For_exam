using Microsoft.EntityFrameworkCore;

namespace MarketMVC.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
