using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record FreeTime() : Card("Free Time", "Move 1 space in any path", "", 4, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<DeckName>.Choice(), 1);
    }
}