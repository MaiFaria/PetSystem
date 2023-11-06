using Microsoft.AspNetCore.Mvc;
using PetSystem.Core.Entities.Requests.ClienteRequests;

namespace PetSystem.Core.UseCases.Contracts;

public interface IClientService
{
    Task<ActionResult> Insert(InsertClientRequest request);
    Task<ActionResult> Update(UpdateClientRequest request);
    Task<ActionResult> GetById(Guid id);
    Task<ActionResult> Delete(Guid id);
}
