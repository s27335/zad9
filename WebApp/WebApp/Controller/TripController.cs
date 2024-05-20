using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Controller;

[ApiController]
[Route("api/trips")]
public class TripController : ControllerBase
{
    
    //insert into Client(IdClient,FirstName, LastName, Email, Telephone, Pesel) VALUES (1,'John', 'Doe', 'doe@wp.pl', '543-323-542','91040294554');
    //insert into trip(IdTrip,Name, Description, DateFrom, DateTo, MaxPeople) VALUES (1,'ABC','Lorem ipsum...', '25-MAY-2024', '31-MAY-2024', 20);
    //insert into trip(IdTrip,Name, Description, DateFrom, DateTo, MaxPeople) VALUES (2,'ABC','Lorem ipsum...', '10-MAY-2024', '17-MAY-2024', 20);
    //Insert into country(IdCountry, Name) values (1, 'Poland');
    //Insert into country(IdCountry, Name) values (2, 'Germany');
    //insert into Country_Trip(IdCountry, IdTrip) values (2,1);

    [HttpGet]
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken)
    {
        ApbdContext context = new();
        List<Trip> trips = await context.Trips.ToListAsync(cancellationToken);

        return Ok(trips);
    }

    [HttpPost]
    public async Task<IActionResult> AddCLientTrips(CancellationToken cancellationToken)
    {
        return Ok();
    }
}