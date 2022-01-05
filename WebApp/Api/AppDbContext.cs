using Microsoft.EntityFrameworkCore;
using WebApp.Api.DatabaseMappings.Configurations;
using WebApp.Api.DatabaseMappings.Entities;

namespace WebApp.Api
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