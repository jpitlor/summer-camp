using dev.pitlor.SummerCamp.Models;
using dev.pitlor.SummerCamp.Services;
using Microsoft.AspNetCore.SignalR;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Hubs;

public class GamesHub : Hub
{
    private readonly GamesService _gamesService;

    public GamesHub(GamesService gamesService)
    {
        _gamesService = gamesService;
        _gamesService.OnGameUpdated += HandleGameUpdated;
    }

    private void HandleGameUpdated(object? sender, Game game)
    {
        var clients = game.Players.Values
            .Where(p => p.ConnectionId != null)
            .Select(p => p.ConnectionId)
            .Cast<string>();
        Clients.Clients(clients).SendAsync("GameUpdated", game);
    }

    public string? TryReconnect(string playerId)
    {
        return _gamesService.GetExistingGameIdAndUpdateConnectionId(playerId, Context.ConnectionId);
    }

    public void CreateGame(string gameId, Path path1, Path path2, Path path3, string playerId)
    {
        _gamesService.CreateGame(gameId, path1, path2, path3, playerId, Context.ConnectionId);
    }

    public void JoinGame(string gameId, string playerId)
    {
        _gamesService.JoinGame(gameId, playerId, Context.ConnectionId);
    }

    public void UpdatePlayer(string gameId, string playerId, string name, Color color)
    {
        _gamesService.UpdatePlayer(gameId, playerId, name, color);
    }

    public void StartGame(string gameId, string playerId)
    {
        _gamesService.StartGame(gameId, playerId);
    }
}