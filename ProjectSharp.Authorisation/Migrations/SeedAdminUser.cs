using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Brokers.Password;
using ProjectSharp.Authorisation.Models.Users;

namespace ProjectSharp.Authorisation.Migrations
{
    public static class SeedUsersAndRolesMigration
    {
        public static async Task SeedAdminUser(
            ILogger logger, 
            IMongoCollection<ApplicationUserModel> applicationUserCollection, 
            IPasswordBroker passwordBroker)
        {
            var searchFilter = Builders<ApplicationUserModel>.Filter.Where(user => user.Role == Roles.Admin.ToString());
            var maybeAdminUser = await applicationUserCollection.Find(searchFilter).FirstOrDefaultAsync();
            if (maybeAdminUser is not null)
                return;
            
            var adminUser = new ApplicationUserModel
            {
                Email = "Administrator",
                Role = Roles.Admin.ToString(),
                PasswordHash = passwordBroker.HashPassword("admin")
            };

            try
            {
                await applicationUserCollection.InsertOneAsync(adminUser);
            }
            catch (Exception e)
            {
                logger.LogCritical(e, "Couldn't create Admin user");
                throw;
            }
        }
    }
}