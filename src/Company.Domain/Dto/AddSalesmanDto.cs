using System.Text.Json.Serialization;
using Company.Domain.Enums;

namespace Company.Domain.Dto;

public class AddSalesmanDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Salesman;

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusType Status {get; set;} = StatusType.Created;

    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = null!;
}