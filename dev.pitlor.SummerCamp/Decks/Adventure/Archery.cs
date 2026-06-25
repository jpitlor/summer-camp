using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record Archery() : Card("Archery", "Move your pawn forward 2 spaces on the adventure path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<DeckName>.Value(DeckName.Adventure), 2);
    }
}