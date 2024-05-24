using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Services;

public class TripService : ITripService
{
    public async Task<List<Trip>> GetTrips(int pageNum,CancellationToken cancellationToken)
    {
        ApbdContext context = new();

        var trips = await context.Trips
            .Select(x => x.Description).ToListAsync(cancellationToken);

        return trips;
    }
}