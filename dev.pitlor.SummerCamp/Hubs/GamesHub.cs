using dev.pitlor.SummerCamp.Models;
using dev.pitlor.SummerCamp.Services;
using Microsoft.AspNetCore.SignalR;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Hubs;

public class GamesHub(GamesService gamesService) : Hub
{
    public string? TryReconnect(string playerId)
    {
        return gamesService.GetExistingGameIdAndUpdateConnectionId(playerId, Context.ConnectionId);
    }

    public void CreateGame(string gameId, Path path1, Path path2, Path path3, string playerId)
    {
        gamesService.CreateGame(gameId, path1, path2, path3, playerId, Context.ConnectionId);
    }

    public void JoinGame(string gameId, string playerId)
    {
        gamesService.JoinGame(gameId, playerId, Context.ConnectionId);
    }

    public void UpdatePlayer(string gameId, string playerId, string name, Color? color)
    {
        gamesService.UpdatePlayer(gameId, playerId, name, color);
    }

    public void StartGame(string gameId, string playerId)
    {
        gamesService.StartGame(gameId, playerId);
    }
}