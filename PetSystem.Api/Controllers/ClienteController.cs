using Microsoft.AspNetCore.Mvc;
using PetSystem.Core.Entities.Requests.ClienteRequests;
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

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateClientRequest request)
    {
        return await _service.Update(request);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        return await _service.GetById(id);
    }
}