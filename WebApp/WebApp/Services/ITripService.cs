using WebApp.DTO;
using WebApp.Entities;

namespace WebApp.Services;

public interface ITripService
{
    public Task<List<DTOTrip>> GetTrips(CancellationToken cancellationToken);
    public Task<bool> ClientExists(AssignClient assignClient, CancellationToken cancellationToken);
    public Task<bool> ClientAssigned(AssignClient assignClient, CancellationToken cancellationToken);
    public Task<bool> TripExists(AssignClient assignClient, CancellationToken cancellationToken);
    public Task AssignClientToTrip(int idTrip, AssignClient client, CancellationToken cancellationToken);
}