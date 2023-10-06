using System.Text.Json.Serialization;
using PetSystem.Core.Entities.ValueObjects;

namespace PetSystem.Core.Entities.Requests;

public class InsertClientRequest
{
    public string Name { get; set; } = string.Empty;
    public Contact Contact { get; set; } = new();
    public Address Address { get; set; } = new();

    [JsonIgnore]
    public DateTime RegistrationDate { get; } = DateTime.Now;
}