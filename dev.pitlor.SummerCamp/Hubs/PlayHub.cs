using dev.pitlor.SummerCamp.Services;
using Microsoft.AspNetCore.SignalR;

namespace dev.pitlor.SummerCamp.Hubs;

public class PlayHub(PlayService playService) : Hub
{
    public void PlayCard()
    {
        
    }

    public void DiscardCard()
    {
        
    }

    public void BuyCard()
    {
        
    }
}