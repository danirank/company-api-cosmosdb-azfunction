namespace Customer.Domain.Entities;
public class CustomerEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;


    public string Address { get; set; } = null!;
    public string Phone { get; set; }  = null!;

    public string Email { get; set; }   = null!;

    public int SalesmanId { get; set; } 
    public Salesman? Salesman { get; set; }

    
}
