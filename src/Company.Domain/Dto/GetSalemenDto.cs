namespace Company.Domain.Dto;
public class GetSalemenDto : AddSalesmanDto
{
    public string Id { get; set; } = null!;
    public string? ErrorMessage { get; set; } = string.Empty;
}