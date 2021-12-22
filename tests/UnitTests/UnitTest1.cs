using System;
using Xunit;
using Recipes;
using System.Linq;
using UnitTests.Mocks;

namespace UnitTests
{
    public class GetRecipesTest : IClassFixture<BaseFixture>, IDisposable
    {
        GetRecipes _sut;
        AppDbContext _context;
        public GetRecipesTest(BaseFixture fixture)
        {
            _context = fixture._context;
            _sut = new GetRecipes(_context);
        }



        [Fact]
        public void Test1()
        {
            var testData = new Data {
                UserName = "test1"
            };
            _context.Add(testData);
            _context.SaveChanges();
            
            var result = _sut.TestMethod();
            Assert.Equal("test1", result);
        }

        [Fact]
        public void Test2() 
        {
            var testData = new Data {
                UserName = "test2"
            };
            _context.Add(testData);
            _context.SaveChanges();
            
            var result = _sut.TestMethod();
            Assert.Equal("test2", result); 
        }

        public void Dispose()
        {
            _context.RemoveRange(_context.Test.ToArray());
        }
    }
}
