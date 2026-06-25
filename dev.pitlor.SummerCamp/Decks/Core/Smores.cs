using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record Smores() : Card("Smores", "Gain 2 energy", "", 2, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getEnergy(2);
    }
}