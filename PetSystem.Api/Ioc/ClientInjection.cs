using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Core.UseCases.Contracts;
using PetSystem.Core.UseCases.ServiceHandlers;
using PetSystem.Infra.ReadOnly;
using PetSystem.Infra.Repositories;

namespace PetSystem.Api.Ioc;

public class ClientInjection : IInjection
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientReadOnly, ClientReadOnly>();
    }
}