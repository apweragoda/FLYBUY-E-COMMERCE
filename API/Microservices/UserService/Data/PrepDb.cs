using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
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

            if(!context.Users.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Users.AddRange(
                    new User() { Username = "Roy", Email = "roy@gmail.com", Password = "roy1234" },
                    new User() { Username = "Xin", Email = "xin@gmail.com", Password = "xin1234" }
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
