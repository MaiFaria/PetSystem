using Bogus;
using PetSystem.Core.Entities.ValueObjects;

namespace PetSystem.Tests;

public static class FakerHelper
{
    public static Guid GetId(this Faker faker)
    {
        return faker.Random.Guid();
    }

    public static string GetName(this Faker faker)
    {
        return faker.Name.FirstName() + " " + faker.Name.LastName();
    }

    public static Contact GetContact(this Faker faker)
    {
        var contact = new Contact
        {
            Email = faker.Person.Email,
            MainPhoneNumber = faker.Person.Phone,
            OptionalPhoneNumber = faker.Person.Phone
        };

        return contact;
    }

    public static Address GetAddress(this Faker faker)
    {
        var address = new Address
        {
            PublicPlace = faker.Address.FullAddress(),
            District = faker.Address.Country(),
            City = faker.Address.City(),
            State = faker.Address.State()
        };

        return address;
    }
}

