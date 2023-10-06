namespace PetSystem.Core.Entities.ValueObjects;

public class Address
{
    public string PublicPlace { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}