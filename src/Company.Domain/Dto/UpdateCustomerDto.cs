using System.Text.Json.Serialization;
using Company.Domain.Enums;

namespace Company.Domain.Dto;


public class UpdateCustomerDto
{
     public string? Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EntityType Type { get; set; } = EntityType.Customer;

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusType Status {get; set;} = StatusType.Updated;
    public string? Title { get; set; } = null!;

    public string? Address { get; set; } = null!;
    public string? Phone { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? SalesmanEmail { get; set; } 

    
}