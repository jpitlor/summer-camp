using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record MountainBiking() : Card("Mountain biking", "Move your pawn forward 3 spaces on the adventure path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<DeckName>.Value(DeckName.Adventure), 3);
    }
}