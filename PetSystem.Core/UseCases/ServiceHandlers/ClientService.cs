using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetSystem.Core.Entities.Models;
using PetSystem.Core.Entities.Requests.ClienteRequests;
using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Core.UseCases.Contracts;
using PetSystem.Shared.Apps;

namespace PetSystem.Core.UseCases.ServiceHandlers;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _repository;
    private readonly IClientReadOnly _readOnly;

    public ClientService(IMapper mapper,
                         IClientRepository repository,
                         IClientReadOnly readOnly)
    {
        _mapper = mapper;
        _repository = repository;
        _readOnly = readOnly;
    }

    public async Task<ActionResult> Insert(InsertClientRequest request)
    {
        var client = _mapper.Map<Client>(request);
        client.RegistrationDate = DateTime.Now;

        await client.ValidateForPersistence();
        if (!client.IsValid)
            return await ApplicationResult.ReturnNo(client,
                                                    client.ValidationResult?.Errors);

        await _repository.Insert(client);

        return await ApplicationResult.ReturnOk(_readOnly.GetById(client.Id));
    }

    public async Task<ActionResult> Update(UpdateClientRequest request)
    {
        var updateClient = await _readOnly.GetByIdClient(request.Id);

        if (updateClient is null)
            return await ApplicationResult.ReturnNo(request,
                                                    "Client not found, try again.");

        UpdateClientValidations(updateClient, request);

        var client = _mapper.Map<Client>(request);

        await client.ValidateForPersistence();
        if (!client.IsValid)
            return await ApplicationResult.ReturnNo(client,
                                                    client.ValidationResult?.Errors);

        await _repository.Update(client);

        return await ApplicationResult.ReturnOk(_readOnly.GetById(request.Id));
    }

    public async Task<ActionResult> GetById(Guid id)
    {
        return await ApplicationResult.ReturnOk(_readOnly.GetById(id));
    }

    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteClient = await _readOnly.GetById(id);

        if (deleteClient is null)
            return await ApplicationResult.ReturnNo(null,
                                                    "Client not found, try again.");

        await _repository.Delete(deleteClient);

        return await ApplicationResult.ReturnOk(deleteClient, "Successful operation.");
    }

    #region Validations

    private static void UpdateClientValidations(Client updateClient,
                                                UpdateClientRequest request)
    {
        if (!updateClient.Name.Equals(request.Name))
            updateClient.UpdateName(request.Name);

        if (!updateClient.Contact.Equals(request.Contact))
            updateClient.Contact.UpdateContact(request.Contact);

        if (!updateClient.Address.Equals(request.Address))
            updateClient.Address.UpdateAddress(request.Address);
    }

    #endregion
}