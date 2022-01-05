using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Api;

[assembly: FunctionsStartup(typeof(WebApp.StartUp))]
namespace WebApp
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");
            builder.Services.AddDbContext<AppDbContext>(
              options => options.UseSqlServer(connectionString));
        }
    }
}