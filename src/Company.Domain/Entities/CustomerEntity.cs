using Company.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Company.Domain.Entities;

public class CustomerEntity
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Customer;

    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public StatusType Status { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("title")]
    public string Title { get; set; } = null!;

    [JsonProperty("address")]
    public string Address { get; set; } = null!;

    [JsonProperty("phone")]
    public string Phone { get; set; } = null!;

    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("salesmanEmail")]
    public string? SalesmanEmail { get; set; } = string.Empty;

    [JsonProperty("salesman")]
    public Salesman? Salesman { get; set; }
}