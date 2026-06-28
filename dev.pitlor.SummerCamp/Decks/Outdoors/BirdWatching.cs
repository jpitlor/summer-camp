using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record BirdWatching() : Card("Bird watching", "Draw 3 cards then discard 3 cards", "", 5, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.drawCards(DeckLocation.DrawPile, 3);
        gameEffects.discardCards(ChoiceOrValue<int>.Value(3));
    }
}