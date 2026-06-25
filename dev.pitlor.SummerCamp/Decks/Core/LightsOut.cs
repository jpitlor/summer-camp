using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record LightsOut(): Card("Lights Out", "No action", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        throw new NotImplementedException();
    }
}