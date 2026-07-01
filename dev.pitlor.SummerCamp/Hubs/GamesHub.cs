using dev.pitlor.SummerCamp.Services;
using Microsoft.AspNetCore.SignalR;

namespace dev.pitlor.SummerCamp.Hubs;

public class GamesHub(GamesService gamesService) : Hub
{
    
}