using PetSystem.Core.Entities.ValueObjects;

namespace PetSystem.Core.Entities.Requests.ClienteRequests;

public class InsertClientRequest
{
    public string Name { get; set; } = string.Empty;
    public Contact Contact { get; set; } = new();
    public Address Address { get; set; } = new();
}