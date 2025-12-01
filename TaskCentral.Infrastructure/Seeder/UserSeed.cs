using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Domain.Role;
using TaskCentral.Domain.User;

namespace TaskCentral.Infrastructure.Seeder
{
    public static class UserSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new AppRole { Name = role });
                }
            }

            var email = "abdullah@mail.com";
            var user = await userManager.FindByNameAsync("abdullah");

            if(user == null)
            {
                user = new AppUser
                {
                    UserName = "abdullah",
                    FullName = "Abdullah Bozdağ",
                    Email = email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "abdullah123*");
            }

            if(!await userManager.IsInRoleAsync(user, "Admin"))
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
