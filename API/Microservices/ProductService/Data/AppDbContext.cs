using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ProductService.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProductService.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> opt;

        public AppDbContext(DbContextOptions<AppDbContext> opt)
        {
            this.opt = opt;
        }
       
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ProductsConn");
                    optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}