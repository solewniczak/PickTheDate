using System;
using System.Linq;
using System.Threading.Tasks;
using PickTheDate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PickTheDate
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services) {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync("Administrator");
            
            if (alreadyExists) return;
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
        }
        
        private static async Task EnsureTestAdminAsync(
            UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "szol@eti.pg.edu.pl")
                .SingleOrDefaultAsync();
            
            if (testAdmin != null) return;
            
            testAdmin = new ApplicationUser
            {
                UserName = "szol@eti.pg.edu.pl",
                Email = "szol@eti.pg.edu.pl",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(testAdmin, "NotSecure123!!");
            await userManager.AddToRoleAsync(testAdmin, "Administrator");
        }
    }
}