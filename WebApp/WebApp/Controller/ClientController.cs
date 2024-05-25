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

    [HttpDelete("{idclient:int}")]
    public async Task<IActionResult> DeleteClient(CancellationToken cancellationToken)
    {
        return Ok();
    }

}