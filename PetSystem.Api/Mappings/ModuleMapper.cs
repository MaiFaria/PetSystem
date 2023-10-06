namespace PetSystem.Api.Mappings;

public static class ModuleMapper
{
    public static void MapModules(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies(),
                               ServiceLifetime.Scoped);
    }
}