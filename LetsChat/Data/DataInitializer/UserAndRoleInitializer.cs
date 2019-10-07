using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Data.DataInitializer
{
    public class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("Grimnik@Admin.com").Result == null)
            {

                PasswordHasher<IdentityUser> passwordHash = new PasswordHasher();
                IdentityUser user = new IdentityUser()
                {
                    UserName = "Grimnik@Admin.com",
                    Email = "Grimnik@Admin.com",
                };
                IdentityResult result = userManager.CreateAsync(user, "Admin_1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("Joske@Member.com").Result == null)
            {
                PasswordHasher<IdentityUser> passwordHash = new PasswordHasher();
                IdentityUser user = new IdentityUser()
                {
                    UserName = "Joske@Member.com",
                    Email = "Joske@Member.com",
                };
                IdentityResult result = userManager.CreateAsync(user, "Member_1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {



            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
