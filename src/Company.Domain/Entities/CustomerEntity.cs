using Newtonsoft.Json;

namespace Company.Domain.Entities;

public class CustomerEntity
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;


    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SalesmanEmail { get; set; } = string.Empty;

    public Salesman? Salesman { get; set; }


}
