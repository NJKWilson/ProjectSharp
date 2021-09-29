using System;

namespace ProjectSharp.WebApi.DbModel
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}