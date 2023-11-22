using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ShippingService.Models;

namespace ShippingService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Shipping> Shippings { get; set; }
        
        

    }
}