using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ProjectSharp.Authorisation.Entities.User;

namespace ProjectSharp.Authorisation.Migrations
{
    public static class SeedAdminUser
    {
        public static void SeedAdmin(
            UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            ILogger logger)
        {
            SeedRoles(roleManager, logger);
            SeedUser(userManager, logger);
            AddAdminToAdminUserRole(userManager, logger);
        }
        
        private static void SeedRoles(RoleManager<UserRole> roleManager, ILogger logger)
        {
            if (!roleManager.RoleExistsAsync(UserRoleEnum.User.ToString()).Result)
            {
                logger.LogInformation("No Admin role found seeding");
                var role = new UserRole
                {
                    Name = UserRoleEnum.User.ToString()
                };
                
                var roleResult = roleManager.CreateAsync(role).Result;
                
                if (roleResult.Succeeded)
                {
                    logger.LogInformation("Admin role seeded");
                }
                else
                {
                    logger.LogInformation("Seed Admin role failed");
                }
            }
            
            if (!roleManager.RoleExistsAsync(UserRoleEnum.Admin.ToString()).Result)
            {
                logger.LogInformation("No User role found seeding");
                var role = new UserRole
                {
                    Name = UserRoleEnum.Admin.ToString()
                };
                
                var roleResult = roleManager.CreateAsync(role).Result;
                if (roleResult.Succeeded)
                {
                    logger.LogInformation("User role seeded");
                }
                else
                {
                    logger.LogInformation("Seed User role failed");
                }
            }
        }
        
        private static void SeedUser(UserManager<User> userManager, ILogger logger)
        {
            var adminUser = userManager.FindByEmailAsync("Admin@PSharp.com").Result;

            if (adminUser != null) return;
            
            logger.LogInformation("No Admin user found seeding");
            
            var user = new User()
            {
                UserName = "Admin",
                FirstName = "Admin",
                FamilyName = "ProjectSharp",
                Email = "Admin@PSharp.com",
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = userManager.CreateAsync(user, "Admin!234").Result;
            if (result.Succeeded)
            {
                logger.LogInformation("User seeded");
            }
            else
            {
                logger.LogInformation("Seed User failed");
            }
        }
        
        private static void AddAdminToAdminUserRole(UserManager<User> userManager, ILogger logger)
        {
            var adminUser = userManager.FindByEmailAsync("Admin@PSharp.com").Result;

            if (adminUser == null)
            {
                logger.LogInformation("No admin found to add role");
                return;
            }
            
            var result = userManager.AddToRoleAsync(
                adminUser, UserRoleEnum.Admin.ToString()).Result;
            
            if (result.Succeeded)
            {
                logger.LogInformation("Added admin role to Admin user");
            }
            else
            {
                logger.LogInformation("Failed to add admin role to admin user");
            }
        }
    }
}