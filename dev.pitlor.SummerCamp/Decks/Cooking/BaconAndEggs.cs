using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record BaconAndEggs() : Card("Bacon and eggs", "Gain 3 energy to spend this turn", Path.Cooking, 3, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetEnergy(3);
    }
}