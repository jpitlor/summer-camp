using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.WaterSports;

public record Fishing() : Card("Fishing", "Move 1 space on any path. If you land on a bridge, draw 1 card.", "", 6, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var result = gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Choice(), 1);
        if (result.Effect == Effect.Bridge)
        {
            gameEffects.DrawCards(DeckLocation.DrawPile, 1);
        }
    }
}