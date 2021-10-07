using MongoDB.Bson;

namespace ProjectSharp.Authorisation.Entities
{
    public interface IEntity
    {
        public ObjectId Id { get; set; }
    }
}