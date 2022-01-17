using BackendLink.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLink.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new Users()
                    {
                        FirstName = "Usher",
                        LastName = "John",
                        email = "johnush@gmail.com",
                        IsMale = true,
                        DateRegistered = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
            
        }
    }
}
