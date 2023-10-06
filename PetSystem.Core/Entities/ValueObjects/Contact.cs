namespace PetSystem.Core.Entities.ValueObjects;

public class Contact
{
    public string MainPhoneNumber { get; set; } = string.Empty;
    public string OptionalPhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}