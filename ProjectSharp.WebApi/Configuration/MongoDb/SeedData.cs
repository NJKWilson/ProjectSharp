using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectSharp.WebApi.Brokers.BCryptBroker;
using ProjectSharp.WebApi.Brokers.MongoDb;
using ProjectSharp.WebApi.DbModel.ApplicationUser;

namespace ProjectSharp.WebApi.Configuration.MongoDb
{
    public static class SeedData
    {
        public static void Seed(IDataContext dataContext)
        {
            CheckIfThereIsAdmin(dataContext);
        }

        private static void CheckIfThereIsAdmin(IDataContext dataContext)
        {
            var adminUser = dataContext.Users.Find(Builders<User>.Filter.Where(
                user => user.Email == "admin@psharp.com")).FirstOrDefault();

            if (adminUser == null)
                CreateIndex(dataContext);
        }
        
        private static void CreateIndex(IDataContext dataContext)
        {
            var indexKeyDefinition = Builders<User>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<User>(indexKeyDefinition, indexOptions);

            dataContext.Users.Indexes.CreateOne(indexModel);

            SeedAdmin(dataContext);
        }
        
        private static void SeedAdmin(IDataContext dataContext)
        {
            var passwordService = new PasswordService();

            
            var passwordSalt = Guid.NewGuid().ToString();
            var adminUser = new User()
            {
                FirstName = "Administrator",
                FamilyName = "PSharp",
                Email = "admin@psharp.com",
                Role = UserRole.Admin.ToString(),
                PasswordHash = passwordService.HashPassword("admin", passwordSalt),
                PasswordSalt = passwordSalt,
                CreatedDate = DateTimeOffset.Now,
                CreatedBy = "System"
            };

            dataContext.Users.InsertOne(adminUser);
        }
    }
}