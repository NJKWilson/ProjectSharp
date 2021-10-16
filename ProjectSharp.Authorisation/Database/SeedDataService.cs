// using System;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Logging;
// using ProjectSharp.Authorisation.Brokers.Database;
// using ProjectSharp.Authorisation.Brokers.Password;
// using ProjectSharp.Authorisation.Entities;
// using ProjectSharp.Authorisation.Entities.User;
//
// namespace ProjectSharp.Authorisation.Database
// {
//     public class SeedDataService : ISeedDataService
//     {
//         private readonly ILogger<SeedDataService> _logger;
//         private readonly IDatabaseBroker _databaseBroker;
//         private readonly IStringHashBroker _stringHashBroker;
//         private readonly UserManager<User> _userManager;
//         private readonly RoleManager<UserRole> _roleManager;
//
//         public SeedDataService(
//             ILogger<SeedDataService> logger,
//             IDatabaseBroker databaseBroker,
//             IStringHashBroker stringHashBroker,
//             UserManager<User> userManager,
//             RoleManager<UserRole> roleManager)
//         {
//             _logger = logger;
//             _databaseBroker = databaseBroker;
//             _stringHashBroker = stringHashBroker;
//             _userManager = userManager;
//             _roleManager = roleManager;
//         }
//
//         public async Task SeedAdminUser()
//         {
//             // _logger.LogInformation("Checking for admin account");
//             //
//             // if (!await AdminUserExists())
//             // {
//             //     _logger.LogInformation("Admin account found, skipping seed data");
//             //     return;
//             // }
//             //
//             // _logger.LogInformation("Admin not account found");
//             //
//             // await CreateUniqueIndexOnEmail();
//             // await CreateAdminUser();
//             var z = await _roleManager.CreateAsync(new UserRole() {Name = "Admin"});
//
//             var user = new User()
//             {
//                 UserName = "Admin",
//                 FirstName = "Admin",
//                 FamilyName = "ProjectSharp",
//                 Email = "Admin@PSharp.com",
//                 LockoutEnabled = false,
//                 SecurityStamp = Guid.NewGuid().ToString()
//             };
//
//             await _userManager.CreateAsync(user, "Admin1234!");
//
//             await _userManager.AddToRoleAsync(user, "Admin");
//         }
//
//         // private async Task<bool> AdminUserExists()
//         // {
//         //     var adminUser = await _databaseBroker.FindUserByEmailAsync("admin@psharp.com");
//         //     return adminUser == null;
//         // }
//         //
//         // private async Task CreateUniqueIndexOnEmail()
//         // {
//         //     try
//         //     {
//         //         _logger.LogInformation("Creating index on Email Field");
//         //         await _databaseBroker.CreateIndexOnEmail();
//         //     }
//         //     catch (Exception e)
//         //     {
//         //         _logger.LogCritical(e, "Couldn't create index on Email field");
//         //         throw;
//         //     }
//         //
//         //     _logger.LogInformation("Index created on Email field");
//         // }
//         //
//         // private async Task CreateAdminUser()
//         // {
//         //     var adminUser = new User
//         //     {
//         //         FirstName = "Administrator",
//         //         FamilyName = "PSharp",
//         //         Email = "admin@psharp.com",
//         //         Role = UserRole.Admin.ToString(),
//         //         PasswordHash = _stringHashBroker.HashString("admin"),
//         //         CreatedDate = DateTimeOffset.Now,
//         //         CreatedBy = "System",
//         //         UpdatedDate = DateTimeOffset.Now,
//         //         UpdatedBy = "System"
//         //     };
//         //
//         //     try
//         //     {
//         //         _logger.LogInformation("Seeding Admin user");
//         //         await _databaseBroker.InsertUserAsync(adminUser);
//         //     }
//         //     catch (Exception e)
//         //     {
//         //         _logger.LogCritical(e, "Couldn't create Admin user");
//         //         throw;
//         //     }
//         //
//         //     _logger.LogInformation("Admin user seeded");
//         // }
//     }
// }