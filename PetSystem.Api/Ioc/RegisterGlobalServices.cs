using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Core.Interfaces.Repositories;
using PetSystem.Infra.ReadOnly;
using PetSystem.Infra.Repositories;

namespace PetSystem.Api.Ioc;

public static class RegisterGlobalServices
{
    public static void GlobalServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IBaseReadOnly<>), typeof(BaseReadOnly<>));
    }
}