using Company.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Company.Domain.Entities;

public class Salesman
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Salesman;

    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public StatusType Status { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("phone")]
    public string Phone { get; set; } = null!;

    public Salesman(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}