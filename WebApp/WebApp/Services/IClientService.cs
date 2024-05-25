namespace WebApp.Services;

public interface IClientService
{
    public Task DeleteClient(CancellationToken cancellationToken);
}