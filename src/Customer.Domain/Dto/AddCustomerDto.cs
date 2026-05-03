namespace Customer.Domain.Dto;

public class AddCustomerDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int SalesmanId { get; set; }
}
