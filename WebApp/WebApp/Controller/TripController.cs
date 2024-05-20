using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Controller;

[ApiController]
[Route("api/trips")]
public class TripController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken)
    {
        ApbdContext context = new();
        List<Trip> trips = await context.Trips.ToListAsync(cancellationToken);

        return Ok(trips);
    }
}