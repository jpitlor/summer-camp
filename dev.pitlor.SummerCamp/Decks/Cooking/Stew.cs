using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record Stew() : Card("Stew", "Gain 4 energy to spend this turn", "", 4, 2)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getEnergy(4);
    }
}