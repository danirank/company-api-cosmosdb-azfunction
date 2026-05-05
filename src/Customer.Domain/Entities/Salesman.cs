using Newtonsoft.Json;

namespace Customer.Domain.Entities;

public class Salesman
{
    [JsonProperty("id")]
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;


    public Salesman(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
}
