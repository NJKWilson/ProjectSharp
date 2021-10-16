using System;
using MongoDB.Bson;

namespace ProjectSharp.Authorisation.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}