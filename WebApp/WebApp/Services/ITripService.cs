using WebApp.DTO;
using WebApp.Entities;

namespace WebApp.Services;

public interface ITripService
{
    public Task<List<DTOTrip>> GetTrips(CancellationToken cancellationToken);
    public Task AssignClientToTrip(int idTrip, AssignClient client, CancellationToken cancellationToken);
}