namespace Company.Domain.Dto;

public class GetCustomersDto
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public string? Email { get; set; } = null!;
}