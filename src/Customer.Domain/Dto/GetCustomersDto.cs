namespace Customer.Domain.Dto;

public class GetCustomersDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Email { get; set; } = null!;
}