using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.DTO;
using WebApp.Entities;

namespace WebApp.Services;

public class TripService : ITripService
{
    public async Task<List<DTOTrip>> GetTrips(CancellationToken cancellationToken)
    {
        ApbdContext context = new();

        return await context.Trips
            .Select(t => new DTOTrip()
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries
                    .Select(c => new DTOCountry()
                    {

                        Name = c.Name
                    }).ToList(),
                Clients = t.ClientTrips
                    .Select(c => new DTOClient()
                    {
                        FirstName = c.IdClientNavigation.FirstName,
                        LastName = c.IdClientNavigation.LastName
                    }).ToList()
            }).ToListAsync(cancellationToken);
    }

    public async Task AssignClientToTrip(int idTrip, AssignClient client, CancellationToken cancellationToken)
    {
        
    }
    
    
}