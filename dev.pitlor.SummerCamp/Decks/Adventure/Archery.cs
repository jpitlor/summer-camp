using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record Archery() : Card("Archery", "Move your pawn forward 2 spaces on the adventure path", Path.Adventure, 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Adventure), 2);
    }
}