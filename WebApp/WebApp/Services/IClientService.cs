namespace WebApp.Services;

public interface IClientService
{
    public Task<bool> DeleteClient(int idClient, CancellationToken cancellationToken);
}