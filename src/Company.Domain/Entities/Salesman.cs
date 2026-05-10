using System.Text.Json.Serialization;
using Company.Domain.Enums;
using Newtonsoft.Json;

namespace Company.Domain.Entities;

public class Salesman
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Salesman;

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusType Status {get; set;}
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;


    public Salesman(string id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
}
