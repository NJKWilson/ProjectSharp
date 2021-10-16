using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;

namespace ProjectSharp.Authorisation.Entities.User
{
    public class User : MongoIdentityUser<Guid>, IUser
    {
        //public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        //public string Email { get; set; }
        public string Role { get; set; }
        //public string PasswordHash { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}