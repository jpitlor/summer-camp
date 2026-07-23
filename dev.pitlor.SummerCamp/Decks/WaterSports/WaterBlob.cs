using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.WaterSports;

public record WaterBlob() : Card("Water blob", "Move 2 spaces on any path", Path.WaterSports, 7, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Choice(), 2);
    }
}