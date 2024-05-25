using Microsoft.AspNetCore.Mvc;
using WebApp.DTO;
using WebApp.Services;

namespace WebApp.Controller;

[ApiController]
[Route("api/trips")]
public class TripController : ControllerBase
{
    private ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetTrips(int pageNum,CancellationToken cancellationToken)
    {
        
        var trips = await _tripService.GetTrips(cancellationToken);
        var count = trips.Count;
        var pageSize = 10;
        var allPages = (int)Math.Ceiling((decimal)count / pageSize);
        var productsPerPage = trips
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(new GetTripResponse()
        {
            PageNum = pageNum,
            PageSize = pageSize,
            AllPages = allPages,
            Trips = productsPerPage
        });
    }
    

    [HttpPost("{idTrip:int}/clients")]
    public async Task<IActionResult> AddClientTrips(int idTrip,AssignClient assignClient,CancellationToken cancellationToken)
    {
        var exists = await _tripService.ClientExists(assignClient, cancellationToken);
        if (exists)
        {
            if (!await _tripService.ClientAssigned(assignClient,cancellationToken))
            {
                if (await _tripService.TripExists(assignClient,cancellationToken))
                {
                    await _tripService.AssignClientToTrip(idTrip, assignClient, cancellationToken);
                    return Ok();
                }

                return BadRequest("Dana wycieczka nie istnieje!");
            }

            return BadRequest("Klient jest juz zapisany na ta wycieczke!");
        }
        
        return BadRequest("Klient o podanym Peselu nie istnieje!");
    }
}