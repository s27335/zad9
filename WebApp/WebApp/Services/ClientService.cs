using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Services;

public class ClientService : IClientService
{
    public async Task<bool> DeleteClient(int idClient,CancellationToken cancellationToken)
    {
        ApbdContext context = new();
        var assignedTrips = await context.ClientTrips.AnyAsync(t => t.IdClient == idClient,cancellationToken);
        if (!assignedTrips)
        {
            var client = await context.Clients.FindAsync(idClient, cancellationToken);

            context.Clients.Remove(client);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }
}