using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.WaterSports;

public record Canoeing() : Card("Canoeing", "Move 2 spaces on the water sports path", Path.WaterSports, 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.WaterSports), 2);
    }
}