using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record BaconAndEggs() : Card("Bacon and eggs", "Gain 3 energy to spend this turn", "", 3, 2)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getEnergy(3);
    }
}