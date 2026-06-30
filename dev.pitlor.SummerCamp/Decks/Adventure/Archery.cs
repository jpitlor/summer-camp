using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record Archery() : Card("Archery", "Move your pawn forward 2 spaces on the adventure path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Adventure)), 2);
    }
}