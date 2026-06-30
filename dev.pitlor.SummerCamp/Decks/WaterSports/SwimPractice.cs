using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.WaterSports;

public record SwimPractice()
    : Card("Swim practice", "Move 1 space on the path you have progressed the least on", "", 3, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var progress = new Dictionary<Path, int>
        {
            { game.Deck1.Name, player.Path1Progress },
            { game.Deck2.Name, player.Path2Progress },
            { game.Deck3.Name, player.Path3Progress }
        };
        var min = progress.Values.Min();
        if (progress.Keys.Count(k => progress[k] == min) > 1)
        {
            
        }
    }
}