using dev.pitlor.SummerCamp.Models;
using dev.pitlor.SummerCamp.Services;
using Microsoft.AspNetCore.SignalR;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Hubs;

public class PlayHub(PlayService playService) : Hub
{
    public Result PlayCard(Path path, string cardName)
    {
        return playService.PlayCard(Context.ConnectionId, path, cardName);
    }

    public Result DiscardCard(Path path, string cardName)
    {
        return playService.DiscardCard(Context.ConnectionId, path, cardName);
    }

    public Result BuyCard(Path path, string cardName)
    {
        return playService.BuyCard(Context.ConnectionId, path, cardName);
    }

    public Result EndTurn()
    {
        return playService.EndTurn(Context.ConnectionId);
    }
}