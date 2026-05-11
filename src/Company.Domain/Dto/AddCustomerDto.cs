using System.Text.Json.Serialization;
using Company.Domain.Enums;

namespace Company.Domain.Dto;

public class AddCustomerDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Customer;

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusType Status {get; set;} = StatusType.Created;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("address")]
    public string Address { get; set; } = null!;

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = null!;

    [JsonPropertyName("email")]

    public string Email { get; set; } = null!;

    [JsonPropertyName("salesmanEmail")]
    public string? SalesmanEmail { get; set; } = string.Empty;
}
