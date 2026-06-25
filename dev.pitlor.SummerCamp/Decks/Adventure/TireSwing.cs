using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record TireSwing() : Card("Tire swing", "Move your pawn forward 1 space on the adventure path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<DeckName>.Value(DeckName.Adventure), 1);
    }
}