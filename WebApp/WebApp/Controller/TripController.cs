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
    public async Task<IActionResult> AddClientTrips(int idTrip,AssignClient client,CancellationToken cancellationToken)
    {
        _tripService.AssignClientToTrip(idTrip, client, cancellationToken);
        return Ok();
    }
}