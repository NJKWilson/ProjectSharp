namespace ProjectSharp.DataAccess.Entities;

public interface IAuditable
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public User CreatedBy { get; set; }
    public User? UpdatedBy { get; set; }
}