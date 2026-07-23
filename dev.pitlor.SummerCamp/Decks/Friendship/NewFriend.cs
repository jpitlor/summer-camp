using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record NewFriend() : Card("New friend", "Move your pawn forward 1 space on the friendship path", Path.Friendship, 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Friendship), 1);
    }
}