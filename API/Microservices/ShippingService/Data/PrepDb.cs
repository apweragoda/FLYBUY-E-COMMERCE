using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShippingService.Data;
using ShippingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Data
{
    public static class PrepDb
    {
        public static void PrepData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Shippings.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Shippings.AddRange(
                    new Shipping() { Province = "Western", Town = "Colombo", Fee = 120 },
                    new Shipping() { Province = "Southern", Town = "Galle", Fee = 220 },
                    new Shipping() { Province = "Kandy", Town = "Kandy", Fee = 320 }
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
