using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record NatureWalk() : Card("Nature walk", "Move 1 space on the outdoors path", Path.Outdoors, 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Outdoors), 1);
    }
}