using System;
using Microsoft.EntityFrameworkCore;
using Recipes;

namespace UnitTests.Mocks
{
    public class BaseFixture 
    {
        public readonly AppDbContext _context;

        public BaseFixture() 
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase($"db-{Guid.NewGuid()}")
                .Options;

            _context = new AppDbContext(options);

            Seed();
        }

        protected virtual void Seed()
        {
            _context.SaveChanges();
        }
    }
}