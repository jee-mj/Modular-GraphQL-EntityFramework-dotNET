using Database.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Child!");

            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("database") ?? throw new InvalidOperationException("'database' not found");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("database"));

            builder.Build().Run();
        }
    }
}