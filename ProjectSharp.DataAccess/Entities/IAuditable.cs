namespace ProjectSharp.DataAccess.Entities;

public interface IAuditable
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public User CreatedBy { get; set; }
    public User? UpdatedBy { get; set; }
}