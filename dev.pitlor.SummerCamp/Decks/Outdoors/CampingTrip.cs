using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record CampingTrip() : Card("CampingTrip", "Move 3 spaces on the outdoors path", "", 0, 0)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.moveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Outdoors)), 3);
    }
}