using PetSystem.Core.Entities.SharedContext;
using PetSystem.Core.Entities.ValueObjects;
using PetSystem.Core.Validations;

namespace PetSystem.Core.Entities.Models;

public class Client : BaseEntity
{
    protected Client() { }

    public Client(string name,
                  Contact contact)
    {
        Name = name;
        Contact = contact;
    }

    public string Name { get; set; } = string.Empty;
    public Contact Contact { get; set; } = new();
    public Address Address { get; set; } = new();
    public DateTime RegistrationDate { get; set; }

    public async Task ValidateForPersistence()
    {
        ValidationResult = await new ClientValidations().ValidateAsync(this);
    }
}