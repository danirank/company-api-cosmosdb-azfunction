using Company.Domain.Enums;
using Newtonsoft.Json;

namespace Company.Domain.Dto;

public class OutboxDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
    public OutboxType EventType { get; set; }
    public string CustomerId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}