using System;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data_Access_Layer
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
                
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public  DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public  DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0ASO8CK\\SQLEXPRESS;Initial Catalog=FlyBuyDB;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }*/


        /*public  DbSet<Bill> Bills { get; set; }
        public  DbSet<Shipping> ShippingInfo { get; set; }
        public  DbSet<ShippingOption> ShippingOption { get; set; }
        public  DbSet<RefreshToken> RefreshTokens { get; set; }*/


    }
}
