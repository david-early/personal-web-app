using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

namespace db
{
    class Program
    {
        static int Main(string[] args)
        {

            var cwd = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"{cwd}/appsettings.json")
                .Build();

            string connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");

        #if DEBUG
            connectionString = configuration.GetConnectionString("SQLConnectionString");
        #endif
        
            Console.WriteLine($"connection string = {connectionString}");
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .JournalToSqlTable("dbo", "Migrations_Journal")
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
        #if DEBUG
                Console.ReadLine();
        #endif                
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
