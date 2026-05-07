using System.Text.Json.Serialization;
using Company.Domain.Enums;

namespace Company.Domain.Dto;

public class AddCustomerDto
{
    public string Name { get; set; } = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Customer;
    public string Title { get; set; } = null!;


    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SalesmanEmail { get; set; } = string.Empty;
}
