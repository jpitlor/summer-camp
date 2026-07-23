using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record Smores() : Card("S'mores", "Gain 2 energy", Path.Custom("core"), 2, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetEnergy(2);
    }
}