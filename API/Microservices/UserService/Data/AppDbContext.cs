

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using UserService.Models;

namespace UserService.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> opt;

        public AppDbContext(DbContextOptions<AppDbContext> opt)
        {
            this.opt = opt;
        }

        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("UsersConn");
                    optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}