using Bogus;

namespace PetSystem.Tests.Builders;

public class FakerBuilder
{
    private static string? _language;

    public static FakerBuilder New()
    {
        _language = "pt_BR";

        return new FakerBuilder();
    }

    public Faker Build()
    {
        return new Faker(_language);
    }
}
