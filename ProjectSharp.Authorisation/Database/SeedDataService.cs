using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectSharp.Authorisation.Brokers.Database;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Database
{
    public class SeedDataService : ISeedDataService
    {
        private readonly ILogger<SeedDataService> _logger;
        private readonly IDatabaseBroker _databaseBroker;
        private readonly IPasswordBroker _passwordBroker;

        public SeedDataService(
            ILogger<SeedDataService> logger,
            IDatabaseBroker databaseBroker,
            IPasswordBroker passwordBroker)
        {
            _logger = logger;
            _databaseBroker = databaseBroker;
            _passwordBroker = passwordBroker;
        }

        public async Task SeedAdminUser()
        {
            _logger.LogInformation("Checking for admin account");

            if (!await AdminUserExists())
            {
                _logger.LogInformation("Admin account found, skipping seed data");
                return;
            }

            _logger.LogInformation("Admin not account found");

            await CreateUniqueIndexOnEmail();
            await CreateAdminUser();
        }

        private async Task<bool> AdminUserExists()
        {
            var adminUser = await _databaseBroker.FindUserByEmailAsync("admin@psharp.com");
            return adminUser == null;
        }

        private async Task CreateUniqueIndexOnEmail()
        {
            try
            {
                _logger.LogInformation("Creating index on Email Field");
                await _databaseBroker.CreateIndexOnEmail();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Couldn't create index on Email field");
                throw;
            }

            _logger.LogInformation("Index created on Email field");
        }

        private async Task CreateAdminUser()
        {
            var adminUser = new User
            {
                FirstName = "Administrator",
                FamilyName = "PSharp",
                Email = "admin@psharp.com",
                Role = UserRole.Admin.ToString(),
                PasswordHash = _passwordBroker.HashPassword("admin"),
                CreatedDate = DateTimeOffset.Now,
                CreatedBy = "System",
                UpdatedDate = DateTimeOffset.Now,
                UpdatedBy = "System"
            };

            try
            {
                _logger.LogInformation("Seeding Admin user");
                await _databaseBroker.InsertUserAsync(adminUser);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Couldn't create Admin user");
                throw;
            }

            _logger.LogInformation("Admin user seeded");
        }
    }
}