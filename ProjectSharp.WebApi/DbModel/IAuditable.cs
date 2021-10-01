using System;

namespace ProjectSharp.WebApi.DbModel
{
    public interface IAuditable
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}