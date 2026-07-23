using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record LightsOut(): Card("Lights Out", "No action", Path.Custom("core"), 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        throw new NotImplementedException();
    }
}