using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetSystem.Core.Entities.Models;
using PetSystem.Core.Entities.Requests;
using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Core.UseCases.Contracts;
using PetSystem.Shared.Apps;

namespace PetSystem.Core.UseCases.ServiceHandlers;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _repository;

    public ClientService(IMapper mapper,
                         IClientRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ActionResult> Insert(InsertClientRequest request)
    {
        var client = _mapper.Map<Client>(request);

        await client.ValidateForPersistence();
        if (!client.IsValid)
            return await ApplicationResult.ReturnNo(client, client.ValidationResult?.Errors);

        await _repository.Insert(client);

        return await ApplicationResult.ReturnOk(client);
    }
}