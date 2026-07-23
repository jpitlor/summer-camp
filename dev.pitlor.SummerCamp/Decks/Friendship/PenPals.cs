using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record PenPals() : Card("Pen pals", "Move your pawn forward 3 spaces on the friendship path", Path.Friendship, 8, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Friendship), 3);
    }
}