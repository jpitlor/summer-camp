using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.WaterSports;

public record Sailing() : Card("Sailing", "Move 3 spaces on the water sports path", Path.WaterSports, 8, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.WaterSports), 3);
    }
}