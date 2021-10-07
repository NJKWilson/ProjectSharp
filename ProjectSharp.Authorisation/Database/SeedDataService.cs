using System;
using MongoDB.Driver;
using ProjectSharp.Authorisation.Entities;

namespace ProjectSharp.Authorisation.Database
{
    public class SeedDataService : ISeedDataService
    {
        private readonly IDataContext _dataContext;
        
        public SeedDataService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedAdminUser()
        {
            if (!AdminUserExists())
                return;
            
            CreateUniqueIndexOnEmail();
            CreateAdminUser();
        }
        
        private bool AdminUserExists()
        {
            var adminUser = _dataContext.Users.Find(Builders<User>.Filter.Where(
                user => user.Email == "admin@psharp.com")).FirstOrDefault();

            return adminUser == null;
        }
        
        private void CreateUniqueIndexOnEmail()
        {
            var indexKeyDefinition = Builders<User>.IndexKeys.Ascending(user => user.Email);
            var indexOptions = new CreateIndexOptions() {Unique = true};
            var indexModel = new CreateIndexModel<User>(indexKeyDefinition, indexOptions);

            _dataContext.Users.Indexes.CreateOne(indexModel);
        }
        
        private void CreateAdminUser()
        {
            //var passwordService = new PasswordService();
            
            var passwordSalt = Guid.NewGuid().ToString();
            var adminUser = new User()
            {
                FirstName = "Administrator",
                FamilyName = "PSharp",
                Email = "admin@psharp.com",
                Role = UserRole.Admin.ToString(),
                //PasswordHash = passwordService.HashPassword("admin", passwordSalt),
                //PasswordSalt = passwordSalt,
                CreatedDate = DateTimeOffset.Now,
                CreatedBy = "System"
            };

            _dataContext.Users.InsertOne(adminUser);
        }
    }
}