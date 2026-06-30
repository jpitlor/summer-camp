using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record TireSwing() : Card("Tire swing", "Move your pawn forward 1 space on the adventure path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Adventure)), 1);
    }
}