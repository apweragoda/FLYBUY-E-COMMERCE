using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Data;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data
{
    public static class PrepDb
    {
        public static void PrepData(IApplicationBuilder app, bool isProd)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attemting to apply migrations...");
                try
                {
                    Console.WriteLine("--> Applying migrations...");
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if(!context.Products.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Products.AddRange(
                    new Product() { Name = "Blouse", Category = "Womens", Image = "C:/Users/CRUSHER/Documents/Visual Studio 2019/Backend/Img/product/product-1.jpg", Price = 140, Ratings = 5 },
                    new Product() { Name = "Short Sleeve Shirt", Category = "Mens", Image = "C:/Users/CRUSHER/Documents/Visual Studio 2019/Backend/Img/product/product-2.jpg", Price = 122, Ratings = 4 },
                    new Product() { Name = "Dress", Category = "Womens", Image = "C:/Users/CRUSHER/Documents/Visual Studio 2019/Backend/Img/product/product-3.jpg", Price = 170, Ratings = 5 },
                    new Product() { Name = "Long Sleeve Shirt", Category = "Mens", Image = "C:/Users/CRUSHER/Documents/Visual Studio 2019/Backend/Img/product/product-4.jpg", Price = 150, Ratings = 3 }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
