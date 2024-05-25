using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controller;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{idClient:int}")]
    public async Task<IActionResult> DeleteClient(int idClient, CancellationToken cancellationToken)
    {
        var deleted = await _clientService.DeleteClient(idClient,cancellationToken);

        if (!deleted)
        {
            return BadRequest("Client assigned to trip!");
        }
        return Ok("Client deleted");
    }

}