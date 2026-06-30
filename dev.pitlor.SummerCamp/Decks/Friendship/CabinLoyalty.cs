using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record CabinLoyalty() : Card("Cabin loyalty", "Move your pawn forward 2 spaces on the friendship path", "", 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Friendship)), 2);
    }
}