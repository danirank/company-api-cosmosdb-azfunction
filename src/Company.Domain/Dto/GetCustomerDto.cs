namespace Company.Domain.Dto;

public class GetCustomerDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;


    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SalesmanEmail { get; set; } = string.Empty;
    public string? ErrorMessage { get; set; }  = string.Empty; 
}