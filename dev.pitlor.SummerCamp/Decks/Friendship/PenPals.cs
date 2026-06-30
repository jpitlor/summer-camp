using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record PenPals() : Card("Pen pals", "Move your pawn forward 3 spaces on the friendship path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Friendship)), 3);
    }
}