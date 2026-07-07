using dev.pitlor.SummerCamp.Hubs;
using dev.pitlor.SummerCamp.Models;
using Microsoft.AspNetCore.SignalR;

namespace dev.pitlor.SummerCamp.Services;

public class EventsService(GamesService gamesService, IHubContext<GamesHub> gamesHubContext) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        gamesService.OnGameUpdated += HandleGameUpdated;
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        gamesService.OnGameUpdated -= HandleGameUpdated;
        return Task.CompletedTask;
    }

    private void HandleGameUpdated(object? sender, Game game)
    {
        var clients = game.Players.Values
            .Where(p => p.ConnectionId != null)
            .Select(p => p.ConnectionId)
            .Cast<string>();
        gamesHubContext.Clients.Clients(clients).SendAsync("GameUpdated", game);
    }
}