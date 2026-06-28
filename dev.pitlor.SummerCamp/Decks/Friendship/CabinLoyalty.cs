using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record CabinLoyalty() : Card("Cabin loyalty", "Move your pawn forward 2 spaces on the friendship path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Friendship)), 2);
    }
}