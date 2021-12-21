using Microsoft.EntityFrameworkCore;

namespace Recipes
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new DataConfiguration());
        }
        public DbSet<Data> Test { get; set; }
        
    }
}