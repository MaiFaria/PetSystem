using Bogus;
using PetSystem.Core.Entities.Models;
using PetSystem.Core.Entities.ValueObjects;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace PetSystem.Tests.Builders.Models;

public class ClientBuilder
{
    private readonly Faker _faker;

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Contact Contact { get; set; } = new();
    public Address Address { get; set; } = new();
    public DateTime RegistrationDate { get; set; }
    public ValidationResult ValidationResult { get; set; }

    public ClientBuilder()
     =>   _faker = FakerBuilder.New().Build();

    public ClientBuilder New()
    {
        Id = _faker.GetId();
        Name = _faker.GetName();
        Contact = _faker.GetContact();
        Address = _faker.GetAddress();
        RegistrationDate = DateTime.Now;
        ValidationResult = new ValidationResult();

        return this;
    }

    public Client Build()
    {
        var result = new Client();

        if (Id != null)
            result.Id = Id;

        if (Name != null)
            result.Name = Name;

        if (Contact != null)
            result.Contact = Contact;

        if (Address != null)
            result.Address = Address;

        if (RegistrationDate != null)
            result.RegistrationDate = RegistrationDate;

        if (ValidationResult != null)
            result.ValidationResult = ValidationResult;

        return result;
    }
}
