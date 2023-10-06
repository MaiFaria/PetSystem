using Microsoft.AspNetCore.Mvc;
using PetSystem.Core.Entities.Requests;
using PetSystem.Core.UseCases.Contracts;

namespace PetSystem.Api.Controllers;

[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
        => _service = service;

    [HttpPost]
    public async Task<ActionResult> Insert([FromBody]InsertClientRequest request)
    {
        return await _service.Insert(request);
    }
}