namespace FluentVlidationMVC.Models;

public class Address
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
    public virtual Customer Customer { get; set; }
}
