namespace ProjectSharp.Gui.Database.Entities.Customers;

public class CustomerCompany
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<CustomerContact>? Contacts { get; set; }
}