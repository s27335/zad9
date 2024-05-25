using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.DTO;
using WebApp.Entities;

namespace WebApp.Services;

public class TripService : ITripService
{
    private ApbdContext _context;

    public TripService()
    {
        _context = new ApbdContext();
    }

    public async Task<List<DTOTrip>> GetTrips(CancellationToken cancellationToken)
    {

        return await _context.Trips
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


    public async Task<bool> ClientExists(AssignClient assignClient, CancellationToken cancellationToken)
    {
        var client = await _context.Clients.SingleOrDefaultAsync(c => c.Pesel == assignClient.Pesel, cancellationToken);
        return client != null;
    }

    public async Task<bool> ClientAssigned(AssignClient assignClient, CancellationToken cancellationToken)
    {
        return await _context.ClientTrips
            .AnyAsync(c => c.IdClientNavigation.Pesel == assignClient.Pesel && c.IdTrip == assignClient.IdTrip,
                cancellationToken);
    }

    public async Task<bool> TripExists(AssignClient assignClient, CancellationToken cancellationToken)
    {
        return await _context.Trips
            .AnyAsync(t => t.IdTrip == assignClient.IdTrip, cancellationToken);
    }

    public async Task AssignClientToTrip(int idTrip, AssignClient assignClient,
        CancellationToken cancellationToken)
    {

        var dateFrom = _context.Trips.Single(t => t.IdTrip == assignClient.IdTrip).DateFrom;
        if (dateFrom < DateTime.Now)
        {
            var clientId = _context.Clients.Single(c => c.Pesel == assignClient.Pesel).IdClient;
            var clientTrip = new ClientTrip()
            {
                IdClient = clientId,
                IdTrip = idTrip,
                PaymentDate = assignClient.PaymentDate,
                RegisteredAt = DateTime.Now
            };

            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }


}