using Microsoft.AspNetCore.Mvc;
using PetSystem.Core.Entities.Requests;

namespace PetSystem.Core.UseCases.Contracts;

public interface IClientService
{
    Task<ActionResult> Insert(InsertClientRequest request);
}
