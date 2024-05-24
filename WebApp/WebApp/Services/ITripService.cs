using WebApp.Entities;

namespace WebApp.Services;

public interface ITripService
{
    public Task<List<Trip>> GetTrips(int pageNum,CancellationToken cancellationToken);
}