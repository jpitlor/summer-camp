using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record Stew() : Card("Stew", "Gain 4 energy to spend this turn", Path.Cooking, 4, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetEnergy(4);
    }
}