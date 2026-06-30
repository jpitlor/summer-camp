using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record Boondoggle() : Card("Boondoggle", "Move your pawn forward 1 space on the arts & crafts path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.ArtsAndCrafts)), 1);
    }
}